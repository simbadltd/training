using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using TestTion.App.Core;

namespace TestTion.App.Persistence
{
    internal abstract class BaseRepository : IDisposable
    {
        protected RepositoryContext Context { get; }

        private bool _disposed;

        protected BaseRepository(IDbContextFactory dbContextFactory)
        {
            Context = dbContextFactory.Create();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context?.Dispose();
                }

                _disposed = true;
            }
        }

        ~BaseRepository()
        {
            Dispose(false);
        }

        protected void Delete<T>(Guid id, Func<RepositoryContext, DbSet<T>> dbSetAccessor) where T : DomainObject, new()
        {
            var dummy = new T { Id = id };
            var dbSet = dbSetAccessor(Context);
            dbSet.Attach(dummy);
            dbSet.Remove(dummy);

            Context.SaveChanges();
        }

        protected void Persist<T>(T entity, Func<RepositoryContext, DbSet<T>> dbSetAccessor)
            where T : DomainObject
        {
            var dbSet = dbSetAccessor(Context);
            PersistImpl(entity, dbSet);

            Context.SaveChanges();
        }

        private void PersistImpl<T>(T entity, DbSet<T> dbSet)
            where T : DomainObject
        {
            var origin = dbSet.SingleOrDefault(x => x.Id == entity.Id);
            if (origin != null)
            {
                Context.Entry<T>(origin).CurrentValues.SetValues(entity);
            }
            else
            {
                dbSet.Add(entity);
            }
        }
    }
}
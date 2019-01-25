using System.Data.Entity;
using System.Linq;
using TestTion.App.Core;

namespace TestTion.App.Persistence
{
    public sealed class RepositoryContext : DbContext
    {
        public RepositoryContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<RepositoryContext>());
        }

        public DbSet<Pet> Pets { get; set; }
    }
}
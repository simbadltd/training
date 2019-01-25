using System;
using System.Collections.Generic;
using System.Linq;
using TestTion.App.Core;

namespace TestTion.App.Persistence
{
    internal sealed class PetRepository : BaseRepository, IPetRepository
    {
        public PetRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public List<Pet> GetAll()
        {
            return Context.Pets.ToList();
        }

        public void Save(Pet item)
        {
            Persist(item, x => x.Pets);
        }

        public void Delete(Guid id)
        {
            Delete(id, x => x.Pets);
        }
    }
}
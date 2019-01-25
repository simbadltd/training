using System;
using System.Collections.Generic;
using TestTion.App.Core;

namespace TestTion.App.Persistence
{
    public interface IPetRepository
    {
        List<Pet> GetAll();

        void Save(Pet item);

        void Delete(Guid id);
    }
}
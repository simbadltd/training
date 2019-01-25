using System;
using System.Collections.Generic;
using System.Web.Http;
using TestTion.App.Core;
using TestTion.App.Persistence;

namespace TestTion.App.Controller
{
    public class PetController : ApiController
    {
        private readonly IPetRepository _petRepository;

        public PetController()
        {
            _petRepository = TinyIoC.TinyIoCContainer.Current.Resolve<IPetRepository>();
        }

        // GET api/values
        public IEnumerable<Pet> Get()
        {
            return _petRepository.GetAll();

//            return new[]
//            {
//                new Pet
//                {
//                    Id = Guid.NewGuid(),
//                    BirthDate = new DateTime(2016, 06, 01),
//                    NickName = "Shpenya",
//                    Type = PetType.Parrot
//                },
//                new Pet
//                {
//                    Id = Guid.NewGuid(),
//                    BirthDate = new DateTime(2016, 03, 01),
//                    NickName = "Carl",
//                    Type = PetType.Parrot
//                }
//            };
        }

        public void Post([FromBody] Pet item)
        {
            _petRepository.Save(item);
        }

        public void Put([FromBody] Pet item)
        {
            _petRepository.Save(item);
        }

        public void Delete(string id)
        {
            if (Guid.TryParse(id, out var guid))
            {
                _petRepository.Delete(guid);
            }
        }
    }
}
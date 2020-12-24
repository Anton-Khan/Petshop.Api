using Petshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Extension
{
    public static class PetsMappingExtension
    {
        public static Pet Map(this PetToObjectStucture request)
        {
            var pet = new Pet(request.Type, request.Name, request.Price);
            pet.Id = request.Id;
            return pet;
        }

        public static PetToObjectStucture Map(this Pet pet)
        {
            return new PetToObjectStucture() {
                Type = pet.Type,
                Name = pet.Name,
                Price = pet.Price,
                Id = pet.Id
            };
        }
    }
}

using Petshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Repositories
{
    public interface IPetsRepository
    {
        public IEnumerable<Pet> GetPets();
        public Pet GetPet(Guid petId);
        public IEnumerable<Pet> GetPetByType(String type);
        public Guid AddPet(Pet newPet);
        public Pet RemovePet(Guid petId);
        public void UpdatePet(Pet pet);
    }
}

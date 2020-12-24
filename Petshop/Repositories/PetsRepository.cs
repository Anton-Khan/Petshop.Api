using Petshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Repositories
{
    public class PetsRepository : IPetsRepository
    {
        private readonly Dictionary<Guid, Pet> _pets = new Dictionary<Guid, Pet>();

        public PetsRepository()
        {
            LoadData();
        }

        public Guid AddPet(Pet newPet)
        {
            var pet = newPet.CopyWithNewId();
            _pets.Add(pet.Id, pet);
            return pet.Id;
        }

        public Pet GetPet(Guid petId)
        {
            return _pets[petId];
        }

        public IEnumerable<Pet> GetPetByType(String type)
        {
            var petsByType = _pets.Values.Where(x => x.Type == type);
            return petsByType;
        }

        public IEnumerable<Pet> GetPets()
        {
            return _pets.Select(x => x.Value);
        }

        public Pet RemovePet(Guid petId)
        {
            var removedPet = _pets[petId];
            _pets.Remove(petId);
            return removedPet;
        }

        public void UpdatePet(Pet pet)
        {
            _pets[pet.Id].Update(pet);
        }

        private void LoadData()
        {
            Pet[] newPets = new Pet[5];
            newPets[0] = new Pet("Cat", "Marusia", 10000);
            newPets[1] = new Pet("Dog", "Sharik", 11000);
            newPets[2] = new Pet("Cat", "Pushok", 15000);
            newPets[3] = new Pet("Dog", "Sobaka", 30000);
            newPets[4] = new Pet("Parrot", "Levitan", 100000);

            foreach (Pet item in newPets)
                _pets.Add(item.Id, item);
            
        }
    }
}

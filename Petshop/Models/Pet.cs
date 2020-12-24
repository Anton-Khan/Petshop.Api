using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Models
{
    public class Pet
    {
        public Pet(String type, String name, double price)
        {
            Id = Guid.NewGuid();
            Type = type;
            Name = name;
            Price = price;
        }

        public Pet CopyWithNewId()
        {
            return new Pet(Type, Name, Price);
        }
        public void Update(Pet updatedPet)
        {
            Type = updatedPet.Type;
            Name = updatedPet.Name;
            Price = updatedPet.Price;
        }

        public Guid Id { get; set; }

        public String Type { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
    }
}

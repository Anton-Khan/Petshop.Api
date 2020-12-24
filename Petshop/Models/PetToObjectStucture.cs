using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Models
{
    public class PetToObjectStucture
    {
        public Guid Id { get; set; }
        public String Type { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
    }
}

using Petshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Repositories
{
    public interface ICartRepository
    {
        public IEnumerable<Guid> GetItems();
        public void AddItem(Guid id);
        public void RemoveItem(Guid id);
        public void RemoveAllItems();
    }
}

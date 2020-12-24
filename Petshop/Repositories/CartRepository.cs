using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly List<Guid> _items = new List<Guid>();
        public void AddItem(Guid id)
        {
            if (_items.Contains(id))
                throw new Exception($"Элемент с Id {id} уже был добавлен в вашу корзину.");
        }

        public IEnumerable<Guid> GetItems()
        {
            return _items;
        }

        public void RemoveAllItems()
        {
            _items.Clear();
        }

        public void RemoveItem(Guid id)
        {
            if (!_items.Contains(id))
                throw new Exception($"Элумента с Id {id} нет в вашей корзине.");

            _items.Remove(id);
        }
    }
}

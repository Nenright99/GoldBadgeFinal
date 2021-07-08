using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    public class ItemRepository
    {
        protected readonly List<Items> _itemDirectory = new List<Items>();
        public bool AddItem(Items newItem)
        {
            int count = _itemDirectory.Count();
            _itemDirectory.Add(newItem);
            bool wasAdded = (_itemDirectory.Count() > count) ? true : false;
            return wasAdded;
        }
        public List<Items> GetDirectory()
        {
            return _itemDirectory;
        }
        public Items GetByNumber(int number)
        {
            foreach (Items item in _itemDirectory)
            {
                if (item.Number == number)
                {
                    return item;
                }
            }
            return null;
        }

        public bool RemoveItem(Items item)
        {
            bool removeResult = _itemDirectory.Remove(item);
            return removeResult;
        }

    }
}

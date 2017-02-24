using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstLookatHashTables
{
    class HashTableArrayNode<Tkey,Tvalue>
    {

        LinkedList<HashTableNodePair<Tkey, Tvalue>> _items;

        public void Add(Tkey key, Tvalue value)
        {
            if (_items == null)
            {
                _items = new LinkedList<HashTableNodePair<Tkey, Tvalue>>();
            }
            else
            {
                foreach (var pair in _items)
                {
                    if (pair.Key.Equals(key))
                    {
                        throw new ArgumentException("This collection already exists");
                    }
                }
                   
            }

            _items.AddFirst(new HashTableNodePair<Tkey, Tvalue>(key, value));
        }
    }
}

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

        public void Update(Tkey key, Tvalue value)
        {
            bool updated = false;

            if (_items != null)
            {
                foreach (var pair in _items)
                {
                    if (pair.Key.Equals(key))
                    {
                        pair.Value = value;
                        updated = true;
                        break;
                    }
                }
            }

            if (!updated)
            {
                throw new ArgumentException("The Collection does not contain the key");
            }
        }

        public bool TryGetValue(Tkey key, out Tvalue value)
        {
            value = default(Tvalue);

            bool found = false;

            if (_items != null)
            {
                foreach (var pair in _items)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        public bool Remove(Tkey key)
        {
            bool removed = false;

            if (_items != null)
            {
                LinkedListNode<HashTableNodePair<Tkey, Tvalue>> current = _items.First;
                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        _items.Remove(current);
                        removed = true;
                        break;
                    }

                    current = current.Next;
                }
            }

            return removed;
        }

        public void Clear()
        {
            if (_items != null)
            {
                _items.Clear();
            }
        }

        public IEnumerable<Tvalue> Values
        {
            get
            {
                if (_items != null)
                {
                    foreach (var node in _items)
                    {
                        yield return node.Value;
                    }
                }
            }
        }

        public IEnumerable<Tkey> Keys
        {
            get
            {
                if (_items != null)
                {
                    foreach (var node in _items)
                    {
                        yield return node.Key;
                    }
                }
            }
        }

        public IEnumerable<HashTableNodePair<Tkey,Tvalue>> Items
        {
            get
            {
                if (_items != null)
                {
                    foreach (var node in _items)
                    {
                        yield return node;
                    }
                }
            }
        }

    }
}

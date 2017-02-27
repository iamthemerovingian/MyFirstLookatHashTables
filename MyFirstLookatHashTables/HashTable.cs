using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstLookatHashTables
{
    class HashTable<Tkey, Tvalue>
    {
        const double _fillFactor = 0.75;

        int _maxItemsAtCurrentSize;

        int _count;

        HashTableArray<Tkey, Tvalue> _array;

        public HashTable() : this(1000)
        {

        }

        public HashTable(int initialCapacity)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException("InitialCapacity");
            }

            _array = new HashTableArray<Tkey, Tvalue>(initialCapacity);

            _maxItemsAtCurrentSize = (int)(initialCapacity * _fillFactor) + 1;
        }

        public void Add(Tkey key, Tvalue value)
        {
            if (_count >= _maxItemsAtCurrentSize)
            {
                HashTableArray<Tkey, Tvalue> largerArray = new HashTableArray<Tkey, Tvalue>(_array.Capacity * 2);

                foreach (var node in _array.Items)
                {
                    largerArray.Add(node.Key, node.Value);
                }

                _array = largerArray;

                _maxItemsAtCurrentSize = (int)(_array.Capacity * _fillFactor) + 1;
            }

            _array.Add(key, value);
            _count++;
        }

        public bool Remove(Tkey key)
        {
            bool removed = _array.Remove(key);

            if (removed)
            {
                --_count;
            }

            return removed;
        }

        public Tvalue this[Tkey key]
        {
            get
            {
                Tvalue value;
                if (!_array.TryGetValue(key, out value))
                {
                    throw new ArgumentException("Key");
                }

                return value;
            }
            set
            {
                _array.Update(key, value);
            }
        }

        public bool TryGetValue(Tkey key, out Tvalue value)
        {
            return _array.TryGetValue(key, out value);
        }
    }
}

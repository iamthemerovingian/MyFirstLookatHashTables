using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstLookatHashTables
{
    class HashTableArray<Tkey,Tvalue>
    {
        HashTableArrayNode<Tkey, Tvalue>[] _array;

        public HashTableArray(int capacity)
        {
            _array = new HashTableArrayNode<Tkey, Tvalue>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                _array[i] = new HashTableArrayNode<Tkey, Tvalue>();
            }
        }

        public void Add(Tkey key, Tvalue value)
        {
            _array[GetIndex(key)].Add(key, value);
        }

        public void Update(Tkey key, Tvalue value)
        {
            _array[GetIndex(key)].Update(key, value);
        }

        public bool Remove(Tkey key)
        {
            return _array[GetIndex(key)].Remove(key);
        }

        public bool TryGetValue(Tkey key, out Tvalue value)
        {
            return _array[GetIndex(key)].TryGetValue(key, out value);
        }

        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        public void Clear()
        {
            foreach (var node in _array)
            {
                node.Clear();
            }
        }

        public IEnumerable <Tvalue> Values
        {
            get
            {
                foreach (var node in _array)
                {
                    foreach (var value in node.Values)
                    {
                        yield return value;
                    }
                }
            }
        }

        public IEnumerable<HashTableNodePair<Tkey, Tvalue>> Items
        {
            get
            {
                foreach (var node in _array)
                {
                    foreach (var pair in node.Items)
                    {
                        yield return pair;
                    }
                }
            }
        }

        public int GetIndex(Tkey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstLookatHashTables
{
    class HashTableNodePair<Tkey,Tvalue>
    {
        public HashTableNodePair(Tkey key,Tvalue value)
        {
            Key = key;
            Value = value;
        }

        public Tkey Key { get; private set; }
        public Tvalue Value { get; set; }
    }
}

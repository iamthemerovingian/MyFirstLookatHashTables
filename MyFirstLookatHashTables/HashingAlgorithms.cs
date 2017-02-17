using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstLookatHashTables
{
    public class HashingAlgorithms
    {
        public int AdditiveHash(string input)
        {
            int output = 0;

            foreach (char character in input)
            {
                unchecked
                {
                    output += character;
                }
            }


            return output;
        }

        public int DJB2Hash(string value)
        {
            int hash = 5381;
            int i = 0;

            for (i = 0; i < value.Length; i++)
            {
                unchecked
                {
                    hash = (((hash << 5) + hash) + ((byte)value[i]));
                }
            }

            return hash;
        }

        public int FoldingHash(string input)
        {
            int hashValue = 0;
            int startIndex = 0;
            int currentfourBytes;

            do
            {
                currentfourBytes = GetNextBytes(startIndex, input);
                unchecked
                {
                    hashValue += currentfourBytes;
                }

                startIndex += 4;

            } while (currentfourBytes != 0);

            return hashValue;
        }

        private int GetNextBytes(int startIndex, string str)
        {
            int currentFourBytes = 0;

            currentFourBytes += GetByte(str, startIndex);
            currentFourBytes += GetByte(str, startIndex + 1) << 8;
            currentFourBytes += GetByte(str, startIndex + 2) << 16;
            currentFourBytes += GetByte(str, startIndex + 3) << 24;

            return currentFourBytes;
        }

        private int GetByte(string str, int index)
        {
            if (index < str.Length)
            {
                return (int)str[index];
            }

            return 0;
        }
    }
}

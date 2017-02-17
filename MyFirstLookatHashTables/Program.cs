using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstLookatHashTables
{
    class Program
    {
        private static HashingAlgorithms hasingalgos = new HashingAlgorithms();
        static void Main(string[] args)
        {
            string input;

            do
            {
                input = Console.ReadLine().ToString();
                Console.WriteLine("Hashed Value uisng Additive hash is: " + hasingalgos.AdditiveHash(input));
                Console.WriteLine("Hashed Value uisng DJB2 hash is: " + hasingalgos.DJB2Hash(input));
                Console.WriteLine("Hashed Value uisng Folding hash is: " + hasingalgos.FoldingHash(input));
            } while (input != "quit");

        }
    }
}

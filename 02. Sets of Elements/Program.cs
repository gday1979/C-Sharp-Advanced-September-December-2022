using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int>firstSet=new HashSet<int>();
            HashSet<int>secondSet=new HashSet<int>(); 
            int[]counts=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(n=>int.Parse(n)).ToArray();
            for (int i = 0; i < counts[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < counts[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ",firstSet));
        }
    }
}

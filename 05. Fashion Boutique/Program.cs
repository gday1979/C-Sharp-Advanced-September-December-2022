using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(input);
            int sum =0;
            int racks = 1;
            int capacity = int.Parse(Console.ReadLine());
            while (clothes.Any())
            {
                int curent = clothes.Pop();
                if (sum+curent<=capacity)
                {
                    sum += curent;
                }
                else
                {
                    sum=curent;
                    racks++;
                }
            }
            Console.WriteLine(racks);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCups = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] inputbottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(inputCups);
            Stack<int> bottles = new Stack<int>(inputbottles);

            int wastedOfWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int valueCups = cups.Peek();
                int valueBottles = bottles.Peek();

                int totalValue = valueBottles - valueCups;

                if (totalValue < 0)
                {
                    valueCups = valueCups - valueBottles;
                    bottles.Pop();

                    while (valueCups > 0 && cups.Count > 0 && bottles.Count > 0)
                    {
                        valueBottles = bottles.Pop();
                        totalValue = valueCups;
                        valueCups = valueCups - valueBottles;
                    }

                    cups.Dequeue();
                    wastedOfWater += valueBottles - totalValue;
                }
                else
                {
                    cups.Dequeue();
                    bottles.Pop();
                    wastedOfWater += totalValue;
                }

            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedOfWater}");
        }
    }
}
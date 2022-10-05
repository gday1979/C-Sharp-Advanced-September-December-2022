using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
  .Split()
  .Select(int.Parse)
  .OrderByDescending(n => n)
  .ToArray();
            int count = numbers.Length >= 3 ? 3 : numbers.Length;
            for (int i = 0; i < count; i++)
                Console.Write($"{numbers[i]} ");


        }
    }
}

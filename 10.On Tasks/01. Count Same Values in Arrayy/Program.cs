using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Arrayy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[]values=Console.ReadLine().Split().Select(double.Parse).ToArray();
           Dictionary<double, int> numbers = new Dictionary<double, int>();
            
            for (int i = 0; i < values.Length; i++)
            {
                if (numbers.ContainsKey(values[i]))
                {
                    numbers[values[i]]++;
                }
                else
                {
                    numbers.Add(values[i], 1);      
                }        
            }
            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}

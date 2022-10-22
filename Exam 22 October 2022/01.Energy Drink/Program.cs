using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var caffeineMilligrams = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var energyDrinks = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int drunkCaffeine = 0;

            while (caffeineMilligrams.Any() && energyDrinks.Any())
            {
                int currentEnergyDrink = energyDrinks.Dequeue();
                int currentCaffeine = currentEnergyDrink * caffeineMilligrams.Pop();

                if (drunkCaffeine + currentCaffeine <= 300)
                    drunkCaffeine += currentCaffeine;
                else
                {
                    energyDrinks.Enqueue(currentEnergyDrink);
                    drunkCaffeine = Math.Max(0, drunkCaffeine - 30);
                }
            }

            Console.WriteLine(energyDrinks.Any()
                ? $"Drinks left: {string.Join(", ", energyDrinks)}"
                : "At least Stamat wasn't exceeding the maximum caffeine.");
            Console.WriteLine($"Stamat is going to sleep with {drunkCaffeine} mg caffeine.");
        }
    }
}
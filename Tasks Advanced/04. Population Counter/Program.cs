using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _04.PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> database = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, BigInteger> totalPop = new Dictionary<string, BigInteger>();
            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] elements = input.Split('|');
                string city = elements[0];
                string country = elements[1];
                int population = Convert.ToInt32(elements[2]);
                if (database.ContainsKey(country))
                {
                    database[country].Add(city, population);
                    totalPop[country] += population;
                }
                else
                {
                    totalPop.Add(country, population);
                    database.Add(country, new Dictionary<string, int>());
                    database[country].Add(city, population);
                }

                input = Console.ReadLine();
            }

            foreach (var country in totalPop.OrderByDescending(t => t.Value))
            {
                Console.WriteLine("{0} (total population: {1})", country.Key, country.Value);
                foreach (var city in database[country.Key].OrderByDescending(p => p.Value))
                {
                    Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                }
            }
        }
    }
}

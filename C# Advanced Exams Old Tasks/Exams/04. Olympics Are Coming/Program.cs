using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OlympicsAreComing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> database = new Dictionary<string, List<string>>();
            Dictionary<string, int> totalWins = new Dictionary<string, int>();
            string nameCountry = null;
            char separator = '|';
            string input = Console.ReadLine();
            while (input != "report")
            {
                int indexOfSeparator = input.IndexOf(separator);
                nameCountry = input.Substring(0, indexOfSeparator);
                string name = null;
                string country = null;
                string[] fullName = nameCountry.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < fullName.Length; i++)
                {
                    name += fullName[i];
                    if (i == fullName.Length - 1)
                    {
                        break;
                    }
                    name += ' ';
                }
                nameCountry = input.Substring(indexOfSeparator + 1);
                string[] fullCountry = nameCountry.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < fullCountry.Length; i++)
                {
                    country += fullCountry[i];
                    if (i == fullCountry.Length - 1)
                    {
                        break;
                    }
                    country += ' ';
                }
                if (database.ContainsKey(country))
                {
                    if (database[country].Contains(name))
                    {
                        totalWins[country] += 1;
                    }
                    else
                    {
                        database[country].Add(name);
                        totalWins[country] += 1;
                    }
                }
                else
                {
                    database.Add(country, new List<string>());
                    database[country].Add(name);
                    totalWins.Add(country, 1);
                }

                input = Console.ReadLine();
            }

            foreach (var country in totalWins.OrderByDescending(w => w.Value))
            {
                Console.WriteLine("{0} ({1} participants): {2} wins", country.Key, database[country.Key].Count, country.Value);
            }
        }
    }
}

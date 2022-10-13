using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            var names = new Dictionary<string, Dictionary<string, string>>();

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] tokens = input.Split("=");
                string name = tokens[0];
                string[] pairs = tokens[1].Split(";");


                if (names.ContainsKey(name) == false)
                {
                    names.Add(name, new Dictionary<string, string>());
                }

                foreach (string pair in pairs)
                {
                    string[] kvp = pair.Split(":");
                    string key = kvp[0];
                    string value = kvp[1];

                    if (names[name].ContainsKey(key) == false)
                    {
                        names[name].Add(key, "");
                    }

                    names[name][key] = value;

                }
            }

            string[] killName = Console.ReadLine().Split();
            int infoIndex = 0;

            Console.WriteLine($"Info on {killName[1]}:");

            foreach (var kvp in names[killName[1]].OrderBy(x => x.Key))
            {
                infoIndex += kvp.Key.Length;
                infoIndex += kvp.Value.Length;

                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine($"Info index: {infoIndex}");

            if (targetInfoIndex <= infoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var assult = new Dictionary<string, Dictionary<string, int>>();


            while (input != "Count em all")
            {
                if (input == "Count em all")
                {
                    break;
                }
                string[] tokens = input.Split(new[] { '-', '>' });
                string region = tokens[0].Trim();
                string meteor = tokens[2].Trim();
                int amount = int.Parse(tokens[4]);


                if (!assult.ContainsKey(region))
                {
                    assult[region] = new Dictionary<string, int>();
                }
                if (!assult[region].ContainsKey(meteor))
                {
                    assult[region][meteor] = 0;
                }

                assult[region][meteor] += amount;

                input = Console.ReadLine();
            }
            var result = new Dictionary<string, Dictionary<string, int>>();

            foreach (var location in assult)
            {
                int Green = 0;
                int Red = 0;
                int Black = 0;
                Console.WriteLine(location.Key);
                foreach (var meteor in location.Value)
                {
                    //int Green = 0;
                    //int Red = 0;
                    //int Black = 0;

                    switch (meteor.Key)
                    {
                        case "Green":
                            Green += meteor.Value;
                            if (Green >= 1000000)
                            {
                                Green -= 1000000;
                                Red += 1;
                            }
                            break;
                        case "Red":
                            Red += meteor.Value;
                            if (Red >= 1000000)
                            {
                                Red -= 1000000;
                                Black += 1;
                            }
                            break;
                        case "Black":
                            Black += meteor.Value;
                            break;
                    }

                }
                Console.WriteLine("-> " + "Black" + " : " + Black);
                Console.WriteLine("-> " + "Red" + " : " + Red);
                Console.WriteLine("-> " + "Green" + " : " + Green);


            }


            Console.WriteLine();
        }
    }
}
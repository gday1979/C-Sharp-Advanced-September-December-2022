using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AshesOfRoses
{
    using System.Numerics;
    using System.Reflection.Emit;
    using System.Text.RegularExpressions;

    class AshesOfRoses
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var result = new Dictionary<string, Dictionary<string, long>>();

            while (input != "Icarus, Ignite!")
            {
                string[] tokens = input.Split();

                Regex regForRegion = new Regex("^<([A-Z]+[a-z]+)>$");
                Match matchRegion = regForRegion.Match(tokens[1]);
                string region = matchRegion.Groups[1].Value;

                Regex regForColor = new Regex("^<([A-Za-z0-9]+)>$");
                Match matchForColor = regForColor.Match(tokens[2]);
                string color = matchForColor.Groups[1].Value;

                Regex regForAmount = new Regex("^([0-9]+)$");
                Match matchForAmount = regForAmount.Match(tokens[tokens.Length - 1]);
                string amountString = matchForAmount.Groups[1].Value;


                if (!result.ContainsKey(region)
                    && region != ""
                    && tokens[0] == "Grow"
                    && color != ""
                    && amountString != "")
                {
                    result[region] = new Dictionary<string, long>();
                    long amount = long.Parse(amountString);
                    if (!result[region].ContainsKey(color))
                    {
                        result[region][color] = amount;
                    }
                    else
                    {
                        result[region][color] += amount;
                    }
                }
                else if (region != "" && tokens[0] == "Grow" && color != "" && amountString != "")
                {
                    long amount = long.Parse(amountString);
                    if (!result[region].ContainsKey(color))
                    {
                        result[region][color] = amount;
                    }
                    else
                    {
                        result[region][color] += amount;
                    }
                }

                input = Console.ReadLine();
            }

            var orderByRegion = result.OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ThenBy(x => x.Key);

            foreach (var region in orderByRegion)
            {
                Console.WriteLine(region.Key);
                var orderByColors = region.Value.OrderBy(x => x.Value)
                    .ThenBy(x => x.Key);
                foreach (var color in orderByColors)
                {
                    Console.WriteLine($"*--{color.Key} | {color.Value}");
                }
            }
        }
    }
}

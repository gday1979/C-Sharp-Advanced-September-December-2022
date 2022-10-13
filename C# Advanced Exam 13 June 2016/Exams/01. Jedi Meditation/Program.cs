using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> masters = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padawans = new Queue<string>();
            Queue<string> toshkoAndSlav = new Queue<string>();

            bool isYodaMeditate = false;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] jedies = line.Split(' ');
                for (int j = 0; j < jedies.Length; j++)
                {
                    string jedi = jedies[j].Substring(0, 1);

                    switch (jedi)
                    {
                        case "m":
                            masters.Enqueue(jedies[j]);
                            break;
                        case "k":
                            knights.Enqueue(jedies[j]);
                            break;
                        case "p":
                            padawans.Enqueue(jedies[j]);
                            break;
                        case "t":
                        case "s":
                            toshkoAndSlav.Enqueue(jedies[j]);
                            break;
                        case "y":
                            isYodaMeditate = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (isYodaMeditate)
            {
                StringBuilder output = new StringBuilder();
                output.Append(string.Join(" ", masters) + " ");
                output.Append(string.Join(" ", knights) + " ");
                output.Append(string.Join(" ", toshkoAndSlav) + " ");
                output.Append(string.Join(" ", padawans));
                Console.WriteLine(string.Join(" ", output.ToString().Trim()));
            }
            else
            {
                StringBuilder output = new StringBuilder();
                output.Append(string.Join(" ", toshkoAndSlav) + " ");
                output.Append(string.Join(" ", masters) + " ");
                output.Append(string.Join(" ", knights) + " ");
                output.Append(string.Join(" ", padawans));
                Console.WriteLine(string.Join(" ", output.ToString().Trim()));
            }


        }
    }
}

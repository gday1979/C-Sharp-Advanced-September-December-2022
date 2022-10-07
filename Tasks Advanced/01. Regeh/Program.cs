using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01_Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> indexes = FindIndexes(input);


            FindAndPrintSymbols(input, indexes);
        }

        private static void FindAndPrintSymbols(string input, List<int> indexes)
        {
            int sum = 0;

            foreach (int index in indexes)
            {
                sum += index;
                int charIndex = sum % (input.Length - 1);
                Console.Write(input[charIndex + 1]);
            }
            Console.WriteLine();
        }

        private static List<int> FindIndexes(string input)
        {
            Regex regex = new Regex(@"\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA-Z]+\]");
            List<int> indexes = new List<int>();

            foreach (Match match in regex.Matches(input))
            {
                indexes.Add(int.Parse(match.Groups[1].Value));
                indexes.Add(int.Parse(match.Groups[2].Value));
            }

            return indexes;
        }
    }
}

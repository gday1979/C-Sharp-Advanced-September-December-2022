using System;
using System.Text.RegularExpressions;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            string patern = @"s:([^;]+)\;r:([^;]+)\;m\-\-(""[a-zA-Z ]+"")";
            int totalData = 0;


            for (int counter = 0; counter < countOfLines; counter++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, patern);

                foreach (Match match in matches)
                {
                    string sender = MatchLetters(match.Groups[1].ToString());
                    string receiver = MatchLetters(match.Groups[2].ToString());
                    string message = match.Groups[3].ToString();

                    totalData += SumDigit(match.ToString());

                    Console.WriteLine($@"{sender} says {message} to {receiver}");

                }
            }

            Console.WriteLine($"Total data transferred: {totalData}MB");
        }

        private static int SumDigit(string text)
        {
            string patern = @"\d";
            int sum = 0;

            MatchCollection matches = Regex.Matches(text, patern);

            foreach (var match in matches)
            {
                sum += int.Parse(match.ToString());
            }

            return sum;
        }

        private static string MatchLetters(string input)
        {
            string patern = @"[A-Za-z ]";

            MatchCollection matches = Regex.Matches(input, patern);
            string result = string.Empty;

            foreach (var match in matches)
            {
                result += match.ToString();
            }

            return result;
        }
    }
}
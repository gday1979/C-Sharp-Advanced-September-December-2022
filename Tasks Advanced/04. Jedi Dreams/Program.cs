using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.JediDreams
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                text.Append(input);
            }
            //([A-Z]{1}[a-zA-Z]+)\(
            Regex keyReg = new Regex(@"static\s.+?\s([a-zA-Z]*[A-Z]{1}[a-zA-Z]*)");

            MatchCollection keyMathes = keyReg.Matches(text.ToString());

            foreach (Match key in keyMathes)
            {
                string keyKey = key.Groups[1].Value;
                if (!dict.ContainsKey(keyKey))
                {
                    dict[keyKey] = new List<string>();
                }
            }

            Console.WriteLine();
        }
    }
}

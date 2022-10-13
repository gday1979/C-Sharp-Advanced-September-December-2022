using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.JediCodeX
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                text.Append(input);
            }

            string namePattern = Console.ReadLine();
            string messagePattern = Console.ReadLine();
            int[] messageIndex = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Regex nameReg = new Regex(string.Format(@"{0}([a-zA-Z]{{{1}}})(?![a-zA-Z])", Regex.Escape(namePattern), namePattern.Length));
            Regex messageReg = new Regex(string.Format(@"{0}([a-zA-Z0-9]{{{1}}})(?![a-zA-Z0-9])", Regex.Escape(messagePattern), messagePattern.Length));

            List<string> jedi = new List<string>();
            List<string> message = new List<string>();

            MatchCollection jediMaches = nameReg.Matches(text.ToString());
            MatchCollection messageMathes = messageReg.Matches(text.ToString());

            foreach (Match jediMatch in jediMaches)
            {
                jedi.Add(jediMatch.Groups[1].Value);
            }

            foreach (Match messageMatch in messageMathes)
            {
                message.Add(messageMatch.Groups[1].Value);
            }

            int currentJadeIndex = 0;

            List<string> result = new List<string>();

            for (int i = 0; i < messageIndex.Length; i++)
            {
                if (messageIndex[i] - 1 < message.Count)
                {
                    result.Add(string.Format("{0} - {1}", jedi[currentJadeIndex], message[messageIndex[i] - 1]));
                    currentJadeIndex++;
                }
                if (currentJadeIndex >= jedi.Count)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}

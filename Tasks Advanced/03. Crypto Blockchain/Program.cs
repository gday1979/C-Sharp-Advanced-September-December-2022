using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();

            for (int counter = 0; counter < countOfLines; counter++)
            {
                string input = Console.ReadLine();
                text.Append(input);
            }

            string patern = @"((\{([^\d\{]+)?(\d+)([^\d\}]+)?\})|(\[([^\d\[]+)?(\d+)([^\d\]]+)?\]))";
            Regex regex = new Regex(patern);
            StringBuilder cryptoText = new StringBuilder();
            MatchCollection matches = regex.Matches(text.ToString());

            foreach (Match block in matches)
            {
                int blockLength = block.ToString().Length;

                Match numText = Regex.Match(block.ToString(), @"\d+");
                int digits = numText.ToString().Length;
                string numbers = numText.ToString();

                if (digits >= 3 && digits % 3 == 0)
                {
                    string askiiCode = ConvertToAskii(numbers, blockLength);
                    cryptoText.Append(askiiCode);
                }
            }

            Console.WriteLine(cryptoText);
        }

        private static string ConvertToAskii(string numText, int blockLength)
        {
            string askiiString = string.Empty;

            for (int counter = 0; counter < numText.Length / 3; counter++)
            {
                string currTextNum = numText.Substring(counter * 3, 3);
                int currNumber = int.Parse(currTextNum);
                int askiiNumber = currNumber - blockLength;
                char askii = (char)askiiNumber;
                askiiString += askii;
            }

            return askiiString;
        }
    }
}

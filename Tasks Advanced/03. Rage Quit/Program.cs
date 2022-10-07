using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            int startIndex = 0;
            HashSet<char> uniqu = new HashSet<char>();
            StringBuilder letter = new StringBuilder();
            StringBuilder result = new StringBuilder();
            StringBuilder numbera = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]))
                {
                    input[i] = Char.ToUpper(input[i]);
                }
                if (Char.IsDigit(input[i]))
                {
                    for (int j = i; j < input.Length; j++)
                    {
                        if (Char.IsDigit(input[j]))
                        {
                            numbera.Append(input[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    string count = numbera.ToString();
                    int haha = Convert.ToInt32(count);
                    if (haha == 0)
                    {
                        goto done;
                    }
                    for (int j = startIndex; j < i; j++)
                    {
                        letter.Append(input[j]);
                        uniqu.Add(input[j]);
                    }

                    for (int j = 0; j < haha; j++)
                    {
                        result.Append(letter);
                    }
                done:
                    letter.Clear();
                    numbera.Clear();
                    startIndex = i + 1;
                }
            }
            Console.WriteLine("Unique symbols used: {0}", uniqu.Count);
            Console.WriteLine(result);
        }
    }
}
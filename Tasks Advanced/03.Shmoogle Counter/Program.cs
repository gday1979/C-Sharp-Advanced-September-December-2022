using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShmoogleCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> ints = new List<string>();
            List<string> doubles = new List<string>();
            string name = null;

            while (input != "//END_OF_CODE")
            {
                for (int i = 0; i < input.Length - 7; i++)
                {
                    if (input[i] == 'i' && input[i + 1] == 'n' && input[i + 2] == 't' && input[i + 3] == ' ' && Char.IsLower(input[i + 4]))
                    {
                        for (int j = i + 4; j < input.Length; j++)
                        {
                            if (!Char.IsLetterOrDigit(input[j]))
                            {
                                name = input.Substring(i + 4, j - (i + 4));
                                ints.Add(name);
                                break;
                            }
                        }
                    }
                    if (input[i] == 'd' &&
                        input[i + 1] == 'o' &&
                        input[i + 2] == 'u' &&
                        input[i + 3] == 'b' &&
                        input[i + 4] == 'l' &&
                        input[i + 5] == 'e' &&
                        input[i + 6] == ' ' &&
                        Char.IsLower(input[i + 7]))
                    {
                        for (int j = i + 7; j < input.Length; j++)
                        {
                            if (!Char.IsLetterOrDigit(input[j]))
                            {
                                name = input.Substring(i + 7, j - (i + 7));
                                doubles.Add(name);
                                break;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }
            if (doubles.Count == 0)
            {
                doubles.Add("None");
            }
            if (ints.Count == 0)
            {
                ints.Add("None");
            }
            doubles.Sort();
            ints.Sort();
            Console.WriteLine("Doubles: {0}", string.Join(", ", doubles));
            Console.WriteLine("Ints: {0}", string.Join(", ", ints));
        }
    }
}
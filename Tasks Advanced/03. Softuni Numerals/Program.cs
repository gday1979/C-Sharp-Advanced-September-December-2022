using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _3.Softuni_Numerals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            for (int i = 0; i <= input.Length - 2; i++)
            {
                if (input[i] == 'a' && input[i + 1] == 'a')
                {
                    numbers.Add(0);
                    i++;
                }
                else if (input[i] == 'a' && input[i + 1] == 'b' && input[i + 2] == 'a')
                {
                    numbers.Add(1);
                    i += 2;
                }
                else if (input[i] == 'b' && input[i + 1] == 'c' && input[i + 2] == 'c')
                {
                    numbers.Add(2);
                    i += 2;
                }
                else if (input[i] == 'c' && input[i + 1] == 'c')
                {
                    numbers.Add(3);
                    i++;
                }
                else if (input[i] == 'c' && input[i + 1] == 'd' && input[i + 2] == 'c')
                {
                    numbers.Add(4);
                    i += 2;
                }
            }
            numbers.Reverse();
            BigInteger result = 0;
            BigInteger multiply;
            for (int i = 0; i < numbers.Count; i++)
            {
                multiply = (numbers[i] * BigInteger.Pow(5, i));
                result += multiply;
            }
            Console.WriteLine(result);
        }
    }
}
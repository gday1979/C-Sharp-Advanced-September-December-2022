using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace _01.CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int startIndex = 0;
            int count = 0;
            List<int> xaxa = new List<int>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split();
                if (command[0] == "reverse")
                {
                    startIndex = Convert.ToInt32(command[2]);
                    count = Convert.ToInt32(command[4]);
                    if (count <= array.Length && count >= 0 && startIndex >= 0 && startIndex < array.Length && count + startIndex <= array.Length)
                    {
                        Array.Reverse(array, startIndex, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                if (command[0] == "sort")
                {
                    startIndex = Convert.ToInt32(command[2]);
                    count = Convert.ToInt32(command[4]);
                    if (count <= array.Length && count >= 0 && startIndex >= 0 && startIndex < array.Length && count + startIndex <= array.Length)
                    {
                        Array.Sort(array, startIndex, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                if (command[0] == "rollLeft")
                {
                    string swapElement = null;
                    string swap = null;
                    count = Convert.ToInt32(command[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        RollToLeft(count, array);
                    }

                }
                if (command[0] == "rollRight")
                {
                    count = Convert.ToInt32(command[1]);
                    string swapElement = null;
                    string swap = null;
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        RollToRight(count, array);
                    }

                }

                input = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }

        private static void RollToLeft(int count, string[] array)
        {
            string swapElement;
            string swap;
            for (int i = 0; i < count; i++)
            {
                swapElement = array[0];
                for (int j = 0; j < array.Length - 1; j++)
                {
                    swap = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = swap;
                    if (j == array.Length - 2)
                    {
                        array[j + 1] = swapElement;
                    }
                }
            }
        }

        private static void RollToRight(int count, string[] array)
        {
            string swapElement;
            string swap;
            for (int i = 0; i < count; i++)
            {
                swapElement = array[array.Length - 1];
                for (int j = array.Length - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        array[0] = swapElement;
                        break;
                    }
                    swap = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = swap;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.ArraySlider
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] array = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
            string command = Console.ReadLine();
            int currentIndex = 0;

            while (command != "stop")
            {
                string[] commands = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                BigInteger offset = Convert.ToInt32(commands[0]);
                BigInteger number = Convert.ToInt32(commands[2]);
                if (offset > 0)
                {
                    if (offset + currentIndex >= array.Length)
                    {
                        //for (int i = 0; i < offset; i++)
                        //{
                        //    if (currentIndex == array.Length - 1)
                        //    {
                        //        currentIndex = 0;
                        //    }
                        //    else
                        //    {
                        //        currentIndex++;
                        //    }
                        //}
                        currentIndex = (int)((currentIndex + offset) % array.Length);
                    }
                    else
                    {
                        currentIndex = (int)(currentIndex + offset);
                    }
                }
                else if (offset < 0)
                {
                    if (currentIndex + offset < 0)
                    {
                        //for (int i = 0; i < -offset; i++)
                        //{
                        //    if (currentIndex == 0)
                        //    {
                        //        currentIndex = array.Length - 1;
                        //    }
                        //    else
                        //    {
                        //        currentIndex--;
                        //    }
                        //}
                        offset = offset % array.Length;
                        offset += array.Length;
                        currentIndex = (int)((currentIndex + offset) % array.Length);
                    }
                    else
                    {
                        currentIndex = (int)(currentIndex + offset);
                    }
                }

                switch (commands[1])
                {
                    case "&":
                        array[currentIndex] = array[currentIndex] & number;
                        break;
                    case "|":
                        array[currentIndex] = array[currentIndex] | number;
                        break;
                    case "^":
                        array[currentIndex] = array[currentIndex] ^ number;
                        break;
                    case "+":
                        array[currentIndex] = array[currentIndex] + number;
                        break;
                    case "-":
                        array[currentIndex] = array[currentIndex] - number;
                        break;
                    case "*":
                        array[currentIndex] = array[currentIndex] * number;
                        break;
                    case "/":
                        array[currentIndex] = array[currentIndex] / number;
                        break;
                }
                if (array[currentIndex] < 0)
                {
                    array[currentIndex] = 0;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }
    }
}
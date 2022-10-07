using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] inputArray = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
            string inputCommand = Console.ReadLine();
            while (inputCommand != "end")
            {
                string[] data = inputCommand.Split();
                if (data[0] == "exchange")
                {
                    if (Convert.ToInt32(data[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                        goto xaxa;
                    }
                    try
                    {
                        inputArray = exchangeArray(data, inputArray);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Invalid index");
                    }
                xaxa:;
                }

                if (data[0] == "max")
                {
                    if (data[1] == "even")
                    {
                        MaxEvenIndex(inputArray);
                    }
                    if (data[1] == "odd")
                    {
                        MaxOddIndex(inputArray);
                    }
                }

                if (data[0] == "min")
                {
                    if (data[1] == "even")
                    {
                        MinEvenIndex(inputArray);
                    }
                    if (data[1] == "odd")
                    {
                        MinOddIndex(inputArray);
                    }
                }
                if (data[0] == "first")
                {
                    if (data[2] == "even")
                    {
                        FirstEvenN(inputArray, data);
                    }
                    if (data[2] == "odd")
                    {
                        FirstOddN(data, inputArray);
                    }
                }

                if (data[0] == "last")
                {
                    if (data[2] == "even")
                    {
                        LastEvenN(data, inputArray);
                    }
                    if (data[2] == "odd")
                    {
                        LastOddN(data, inputArray);
                    }
                }
                inputCommand = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", string.Join(", ", inputArray));
        }



        private static void LastEvenN(string[] data, long[] inputArray)
        {
            if (Convert.ToInt32(data[1]) > inputArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int count = 0;
            List<long> numbers = new List<long>();
            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                if (inputArray[i] % 2 == 0)
                {
                    count++;
                    numbers.Add(inputArray[i]);
                }
                if (count == Convert.ToInt32(data[1]))
                {
                    break;
                }
            }
            if (count != 0)
            {
                numbers.Reverse();
                Console.WriteLine("[{0}]", string.Join(", ", numbers));
            }
            else
            {
                Console.WriteLine("[]");
            }
        }

        private static void LastOddN(string[] data, long[] inputArray)
        {
            if (Convert.ToInt32(data[1]) > inputArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int count = 0;
            List<long> numbers = new List<long>();
            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                if (inputArray[i] % 2 != 0)
                {
                    count++;
                    numbers.Add(inputArray[i]);
                }
                if (count == Convert.ToInt32(data[1]))
                {
                    break;
                }
            }
            if (count != 0)
            {
                numbers.Reverse();
                Console.WriteLine("[{0}]", string.Join(", ", numbers));
            }
            else
            {
                Console.WriteLine("[]");
            }
        }

        private static void FirstOddN(string[] data, long[] inputArray)
        {
            if (Convert.ToInt32(data[1]) > inputArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int count = 0;
            List<long> numbers = new List<long>();
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 != 0)
                {
                    count++;
                    numbers.Add(inputArray[i]);
                }
                if (count == Convert.ToInt32(data[1]))
                {
                    break;
                }
            }
            if (count != 0)
            {
                Console.WriteLine("[{0}]", string.Join(", ", numbers));
            }
            else
            {
                Console.WriteLine("[]");
            }
        }

        private static void FirstEvenN(long[] inputArray, string[] data)
        {
            if (Convert.ToInt32(data[1]) > inputArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int count = 0;
            List<long> numbers = new List<long>();
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 == 0)
                {
                    count++;
                    numbers.Add(inputArray[i]);
                }
                if (count == Convert.ToInt32(data[1]))
                {
                    break;
                }
            }
            if (count != 0)
            {
                Console.WriteLine("[{0}]", string.Join(", ", numbers));
            }
            else
            {
                Console.WriteLine("[]");
            }
        }

        private static void MinOddIndex(long[] inputArray)
        {
            int indexOfMaxEven = -1;
            long value = int.MaxValue;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 != 0 && inputArray[i] <= value)
                {
                    indexOfMaxEven = i;
                    value = inputArray[i];
                }
            }
            if (indexOfMaxEven == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexOfMaxEven);
            }
        }

        private static void MinEvenIndex(long[] inputArray)
        {
            int indexOfMaxEven = -1;
            long value = int.MaxValue;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 == 0 && inputArray[i] <= value)
                {
                    indexOfMaxEven = i;
                    value = inputArray[i];
                }
            }
            if (indexOfMaxEven == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexOfMaxEven);
            }
        }

        private static void MaxEvenIndex(long[] inputArray)
        {
            int indexOfMaxEven = -1;
            long value = int.MinValue;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 == 0 && inputArray[i] >= value)
                {
                    indexOfMaxEven = i;
                    value = inputArray[i];
                }
            }
            if (indexOfMaxEven == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexOfMaxEven);
            }
        }

        private static void MaxOddIndex(long[] inputArray)
        {
            int indexOfMaxOdd = -1;
            long value = int.MinValue;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] % 2 != 0 && inputArray[i] >= value)
                {
                    indexOfMaxOdd = i;
                    value = inputArray[i];
                }
            }
            if (indexOfMaxOdd == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexOfMaxOdd);
            }
        }

        private static long[] exchangeArray(string[] data, long[] inputArray)
        {
            int index = Convert.ToInt32(data[1]) + 1;
            long[] newArray = new long[inputArray.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                if (index == inputArray.Length)
                {
                    break;
                }
                newArray[i] = inputArray[index++];
            }
            index = Convert.ToInt32(data[1]) + 1;
            int index2 = 0;
            for (int j = inputArray.Length - index; j < newArray.Length; j++)
            {
                newArray[j] = inputArray[index2++];
            }
            inputArray = newArray;
            return inputArray;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bestCount = 0;

            for (int step = 1; step <= input.Length; step++)
            {

                Queue<int> numbers = new Queue<int>(input);

                for (int startPosition = 0; startPosition < input.Length; startPosition++)
                {
                    bool isValid = true;
                    Queue<int> currNums = new Queue<int>(numbers);
                    int count = 0;

                    while (isValid)
                    {

                        int firstNumber = currNums.Dequeue();
                        currNums.Enqueue(2222);

                        for (int counter = 0; counter < step - 1; counter++)
                        {
                            currNums.Enqueue(currNums.Dequeue());
                        }

                        int secondNumber = currNums.Peek();

                        if (firstNumber >= secondNumber || firstNumber == 2222 || secondNumber == 2222)
                        {
                            isValid = false;
                        }

                        count++;
                        if (count > bestCount)
                        {
                            bestCount = count;
                        }
                    }


                    numbers.Enqueue(numbers.Dequeue());
                }


            }

            Console.WriteLine(bestCount);
        }
    }
}
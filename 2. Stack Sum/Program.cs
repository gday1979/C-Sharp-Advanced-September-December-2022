using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<int> numbers=new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Push(int.Parse(input[i]));
            }
            string[] command=Console.ReadLine().Split();
            while (command[0].ToLower() !="end")
            {
                if (command[0].ToLower()=="add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else
                {
                    int n=int.Parse(command[1]);
                    if (n<=numbers.Count)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine("Sum: " + numbers.Sum());
        }
    }
}

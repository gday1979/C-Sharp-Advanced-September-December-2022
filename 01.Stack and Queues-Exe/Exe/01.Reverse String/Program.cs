using System;
using System.Collections.Generic;
using System.Threading;

namespace _01.Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            foreach ( char characters in input)
            {
                stack.Push(characters);
            }
            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}

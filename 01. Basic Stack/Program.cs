using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] stackArg=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = stackArg[0];
            int removeCnt=stackArg[1];
            int elementToLook=stackArg[2];
            int[] elementsToAppend = Console.ReadLine().Split().Select(int.Parse).ToArray(); 
            Stack<int> stack = new Stack<int>(elementsToAppend);
            //foreach (var el in elementsToAppend)
           // {
             //   stack.Push(el);
            //}
            //
            for (int i = 0; i < removeCnt; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(elementToLook))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count==0)
            {
                Console.WriteLine(stack.Count);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}

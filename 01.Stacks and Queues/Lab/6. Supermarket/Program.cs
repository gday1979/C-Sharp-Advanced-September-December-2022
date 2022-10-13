using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            Queue<string> names = new Queue<string>();
            while (input !="End")
            {
                if (input=="Paid")
                {
                    while (names.Count>0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }

                }
                else
                {
                    names.Enqueue(input);

                }
                input = Console.ReadLine();
            }
            Console.WriteLine(names.Count + " people remaining. ");
        }
    }
}

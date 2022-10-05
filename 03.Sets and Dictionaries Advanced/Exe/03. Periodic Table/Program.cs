using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            HashSet<string> periodic=new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                periodic.UnionWith(elements);
            }
            Console.WriteLine(string.Join(" ",periodic.OrderBy(p=>p)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n=int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder(); 
            Stack<string>states=new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                string[] actionParamas = Console.ReadLine().Split();
                string action = actionParamas[0];
                if (action=="1")
                {
                    states.Push(sb.ToString());
                    string value = actionParamas[1];
                    sb.Append(value);
                }
                else if (action=="2")
                {
                    states.Push(sb.ToString());
                    int count = int.Parse(actionParamas[1]);
                    while (count>0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        count--;
                    }
                }
                else if (action=="3")
                {
                    int elementNumber = int.Parse(actionParamas[1]);
                    Console.WriteLine(sb[elementNumber-1]);
                }
                else
                {
                    sb.Clear();
                    sb.Append(states.Pop());
                }
            }
        }
    }
}

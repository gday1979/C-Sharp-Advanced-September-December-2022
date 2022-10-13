using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]inputCup=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[]inputBotles=Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cups=new Queue<int>(inputCup);
            Stack<int> bottles=new Stack<int>(inputBotles);
            int wastedLiters = 0;
            bool isNewOne = true;
            int currentCup = 0;
            while (cups.Any() && bottles.Any())
            {
                if (isNewOne)
                {
                    currentCup = cups.Peek();
                    isNewOne = false;
                }
                int currentBotles = bottles.Pop();
                if (currentCup-currentBotles <= 0)
                {
                    wastedLiters+=currentCup-currentBotles;
                    cups.Dequeue();
                    isNewOne = true;
                }
                else
                {
                    currentCup-=currentBotles;
                }
            }
            if (cups.Any()) 
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedLiters* -1}");
        }
    }
}

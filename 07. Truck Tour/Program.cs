using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            Queue<int[]> truckTour=new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();   int petrol=input[0];
                int distance=input[1];
                truckTour.Enqueue(new int[] { petrol, distance });
            }
            int startIndex=0;
            while (true)
            {
                int curentPetrol = 0;
                foreach (var info in truckTour)
                {
                    int truckPetrol = info[0];
                    int truckDistance=info[1];
                    curentPetrol += truckPetrol;
                    curentPetrol -= truckDistance;
                    if (curentPetrol<0)
                    {
                        int[] element = truckTour.Dequeue();
                        truckTour.Enqueue(element);
                        startIndex++;
                        break;
                    }
                }
                if (curentPetrol>=0)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    int currGreenLight = greenLightSeconds;
                    int currFreeWindow = freeWindowSeconds;

                    while (currGreenLight != 0 && cars.Count > 0)
                    {
                        string car = cars.Dequeue();
                        int carLength = car.Length;

                        if (currGreenLight >= carLength)
                        {
                            currGreenLight -= carLength;
                        }
                        else if (currGreenLight < carLength)
                        {
                            carLength -= currGreenLight;
                            currGreenLight = 0;

                            if (currFreeWindow >= carLength)
                            {
                                currFreeWindow -= carLength;
                            }
                            else if (currFreeWindow < carLength)
                            {
                                carLength -= currFreeWindow;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[car.Length - carLength]}.");
                                return;
                            }
                        }

                        carsPassed++;
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}

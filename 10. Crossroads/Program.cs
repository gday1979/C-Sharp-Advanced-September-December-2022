using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLigthInSecondes=int.Parse(Console.ReadLine());
            int freeWindowInSeconds=int.Parse(Console.ReadLine());
            string command=Console.ReadLine();
            int passedCars = 0;
            bool isHitting=false;
            Queue<string> cars =new Queue<string>();
            while(command!="END")
            {
                if(command!="green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    int currentGreenLight=greenLigthInSecondes;
                    while (cars.Count>0 && currentGreenLight >0)
                    {
                        string currentCar=cars.Dequeue();
                        if (currentGreenLight-currentCar.Length >=0)
                        {
                            currentGreenLight -= currentCar.Length;
                            passedCars++;
                            continue;
                        }
                        if (currentGreenLight+freeWindowInSeconds-currentCar.Length >=0)
                        {
                            currentGreenLight = 0;
                            passedCars++;
                            continue;
                        }
                        string hittedChar=currentCar.Substring(currentGreenLight+freeWindowInSeconds, 1);
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {hittedChar}.");
                        isHitting=true;
                        Environment.Exit(0);
                    }
                }
                command=Console.ReadLine();
            }
            if (!isHitting)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
            
        }
    }
}

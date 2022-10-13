using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] locksInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int money = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);

            int countOfGun = 0;
            int bulletsShot = 0;

            while (true)
            {


                int bullet = bullets.Pop();
                int @lock = locks.Peek();

                if (bullet <= @lock)
                {
                    Console.WriteLine("Bang!");
                    countOfGun++;
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    countOfGun++;
                }


                if (bullets.Count <= 0 && locks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
                else if (bullets.Count == 0)
                {
                    int moneyEarned = money - ((bulletsShot + countOfGun) * priceOfBullet);
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                    break;
                }

                if (countOfGun == sizeOfTheGunBarrel)
                {
                    bulletsShot += countOfGun;
                    countOfGun = 0;
                    Console.WriteLine("Reloading!");
                }

                if ((locks.Count <= 0 && bullets.Count == 0) || locks.Count <= 0)
                {
                    int moneyEarned = money - ((bulletsShot + countOfGun) * priceOfBullet);
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                    break;
                }
            }
        }
    }
}

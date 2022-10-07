using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.CubicRube
{
    class Program
    {
        private static bool isInMatrix(long[,,] matrix, long dimension)
        {
            bool result = dimension >= 0
                && dimension <= matrix.GetLength(0)
                && dimension <= matrix.GetLength(1)
                && dimension <= matrix.GetLength(2)
                && dimension >= 0;

            return result;
        }
        static void Main(string[] args)
        {
            long dimensions = long.Parse(Console.ReadLine());

            long[,,] cube = new long[dimensions, dimensions, dimensions];
            string[] input = Console.ReadLine().Split(' ');
            long sumCell = 0;
            long count = 0;
            while (input[0] != "Analyze")
            {
                if (input[0] == "Analyze")
                {
                    break;
                }
                long[] con = input.Select(long.Parse).ToArray();
                input = Console.ReadLine().Split(' ');

                long x = con[0];
                long y = con[1];
                long z = con[2];
                long partical = con[3];


                for (int i = 0; i < cube.GetLength(0); i++)
                {
                    if (x == i)
                    {
                        for (int j = 0; j < cube.GetLength(1); j++)
                        {
                            if (y == j)
                            {
                                for (int k = 0; k < cube.GetLength(2); k++)
                                {
                                    if (z == k)
                                    {
                                        if (isInMatrix(cube, dimensions) && partical > 0)
                                        {
                                            cube[i, j, k] += partical;
                                            sumCell += cube[i, j, k];
                                            count++;
                                        }

                                    }

                                }
                            }

                        }

                    }

                }


            }


            Console.WriteLine(sumCell);
            Console.WriteLine(Math.Pow(dimensions, 3.0) - count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.JadiGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            long ivoStarValue = 0;
            int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] matrix = new int[line[0], line[1]];
            FillMatrix(matrix);
            string ivoCordinate = Console.ReadLine();
            while (ivoCordinate != "Let the Force be with you")
            {
                string evilCordinate = Console.ReadLine();
                int[] ivoParsedCordinates = ivoCordinate.Split(' ').Select(int.Parse).ToArray();
                int[] evilParsedCordinates = evilCordinate.Split(' ').Select(int.Parse).ToArray();

                int ivoCurrentRow = ivoParsedCordinates[0];
                int ivoCurrentCol = ivoParsedCordinates[1];

                int evilCurrentRow = evilParsedCordinates[0];
                int evilCurentCol = evilParsedCordinates[1];

                while (evilCurrentRow >= 0 && evilCurentCol >= 0)
                {
                    if (isInMatrix(matrix, evilCurrentRow, evilCurentCol))
                    {
                        matrix[evilCurrentRow, evilCurentCol] = 0;
                    }

                    evilCurrentRow--;
                    evilCurentCol--;
                }

                while (ivoCurrentRow >= 0 && ivoCurrentCol < matrix.GetLength(1))
                {
                    if (isInMatrix(matrix, ivoCurrentRow, ivoCurrentCol))
                    {
                        ivoStarValue += matrix[ivoCurrentRow, ivoCurrentCol];
                    }

                    ivoCurrentRow--;
                    ivoCurrentCol++;
                }

                ivoCordinate = Console.ReadLine();
            }
            Console.WriteLine(ivoStarValue);
        }

        private static bool isInMatrix(int[,] matrix, int givenRow, int givenCol)
        {
            bool result = givenRow >= 0
                && givenRow < matrix.GetLength(0)
                && givenCol < matrix.GetLength(1)
                && givenCol >= 0;

            return result;
        }

        private static void FillMatrix(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = count;
                    count++;
                }
            }
        }
    }
}

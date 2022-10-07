using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NaturesProphet
{
    using System.Collections.Specialized;

    class NaturesProphet
    {
        static int[,] matrix;

        static void Main(string[] args)
        {
            string[] inputDimensions = Console.ReadLine().Split();
            int matrixRow = int.Parse(inputDimensions[0]);
            int matrixCol = int.Parse(inputDimensions[1]);
            matrix = new int[matrixRow, matrixCol];

            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                string[] tokens = input.Split();
                int row = int.Parse(tokens[0]);
                int col = int.Parse(tokens[1]);
                int count = 0;
                for (int currentRow = row - matrix.GetLength(0);
                    currentRow <= matrix.GetLength(0); currentRow++)
                {
                    if (isInMatrix(matrix, currentRow, col))
                    {
                        matrix[currentRow, col]++;
                    }
                }
                for (int currentCol = col - matrix.GetLength(1);
                        currentCol <= matrix.GetLength(1); currentCol++)
                {
                    if (isInMatrix(matrix, currentCol, col))
                    {
                        matrix[row, currentCol]++;
                    }
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[row, col] = 1;
                    }
                }
                input = Console.ReadLine();
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool isInMatrix(int[,] matrix, int givenRow, int givenCol)
        {
            bool result = givenRow >= 0
                && givenRow < matrix.GetLength(0)
                && givenCol < matrix.GetLength(1)
                && givenCol >= 0;

            return result;
        }
    }
}

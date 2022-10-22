using System;
using System.Linq;

namespace _02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            char[,] matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            (int, int) carPos = (0, 0);
            int traveledKM = 0;
            bool finished = false;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                (int, int) direction = command switch
                {
                    "right" => (0, 1),
                    "left" => (0, -1),
                    "up" => (-1, 0),
                    "down" => (1, 0)
                };

                (int, int) newPos = (carPos.Item1 + direction.Item1, carPos.Item2 + direction.Item2);

                if (newPos.Item1 < 0 || newPos.Item2 < 0 || newPos.Item1 >= matrix.GetLength(0)
                    || newPos.Item2 >= matrix.GetLength(1))
                    continue;

                traveledKM += 10;
                carPos = newPos;

                if (matrix[carPos.Item1, carPos.Item2] == 'T')
                {
                    carPos = GetTunnelEnd(matrix, carPos);
                    RemoveTunnels(matrix);
                    traveledKM += 20;
                }
                else if (matrix[carPos.Item1, carPos.Item2] == 'F')
                {
                    finished = true;
                    break;
                }
            }

            matrix[carPos.Item1, carPos.Item2] = 'C';
            Console.WriteLine($"Racing car {racingNumber} " + (finished ? "finished the stage!" : "DNF."));
            Console.WriteLine($"Distance covered {traveledKM} km.");
            PrintMatrix(matrix);
        }

        private static (int, int) GetTunnelEnd(char[,] matrix, (int, int) tunnelStart)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'T' && (row, col) != tunnelStart)
                        return (row, col);
                }
            }

            return (-1, -1);
        }

        private static void RemoveTunnels(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'T')
                        matrix[row, col] = '.';
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}

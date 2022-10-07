using System;

namespace _03
{
    class Program
    {
        static string[,] matrix;
        static int row;
        static int column;
        static int coal;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();
            matrix = new string[size, size];

            for (int rows = 0; rows < size; rows++)
            {
                string[] currRow = Console.ReadLine().Split();

                for (int columns = 0; columns < size; columns++)
                {
                    matrix[rows, columns] = currRow[columns];
                }
            }

            FindMiner();

            for (int counter = 0; counter < commands.Length; counter++)
            {
                if (commands[counter] == "up")
                {
                    if (isOnBoard(row - 1, column))
                    {
                        if (matrix[row - 1, column] == "c")
                        {
                            matrix[row - 1, column] = "*";
                            row = row - 1;
                            if (isHaveCoal() == false)
                            {
                                Console.WriteLine($"You collected all coals! ({row}, {column})");
                                return;
                            }
                        }
                        else if (matrix[row - 1, column] == "e")
                        {
                            row = row - 1;
                            Console.WriteLine($"Game over! ({row}, {column})");
                            return;
                        }
                        else
                        {
                            matrix[row - 1, column] = "*";
                            row = row - 1;
                        }
                    }
                }
                else if (commands[counter] == "down")
                {
                    if (isOnBoard(row + 1, column))
                    {
                        if (matrix[row + 1, column] == "c")
                        {
                            matrix[row + 1, column] = "*";
                            row = row + 1;
                            if (isHaveCoal() == false)
                            {
                                Console.WriteLine($"You collected all coals! ({row}, {column})");
                                return;
                            }
                        }
                        else if (matrix[row + 1, column] == "e")
                        {
                            row = row + 1;
                            Console.WriteLine($"Game over! ({row}, {column})");
                            return;
                        }
                        else
                        {
                            matrix[row + 1, column] = "*";
                            row = row + 1;
                        }
                    }
                }
                else if (commands[counter] == "left")
                {
                    if (isOnBoard(row, column - 1))
                    {
                        if (matrix[row, column - 1] == "c")
                        {
                            matrix[row, column - 1] = "*";
                            column = column - 1;
                            if (isHaveCoal() == false)
                            {
                                Console.WriteLine($"You collected all coals! ({row}, {column})");
                                return;
                            }
                        }
                        else if (matrix[row, column - 1] == "e")
                        {
                            column = column - 1;
                            Console.WriteLine($"Game over! ({row}, {column})");
                            return;
                        }
                        else
                        {
                            matrix[row, column - 1] = "*";
                            column = column - 1;
                        }
                    }
                }
                else if (commands[counter] == "right")
                {
                    if (isOnBoard(row, column + 1))
                    {
                        if (matrix[row, column + 1] == "c")
                        {
                            matrix[row, column + 1] = "*";
                            column = column + 1;
                            if (isHaveCoal() == false)
                            {
                                Console.WriteLine($"You collected all coals! ({row}, {column})");
                                return;
                            }
                        }
                        else if (matrix[row, column + 1] == "e")
                        {
                            column = column + 1;
                            Console.WriteLine($"Game over! ({row}, {column})");
                            return;
                        }
                        else
                        {
                            matrix[row, column + 1] = "*";
                            column = column + 1;
                        }
                    }
                }
            }



            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    if (matrix[rows, columns] == "c")
                    {
                        coal++;
                    }
                }
            }

            Console.WriteLine($"{coal} coals left. ({row}, {column})");

        }

        private static bool isHaveCoal()
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    if (matrix[rows, columns] == "c")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool isOnBoard(int rows, int columns)
        {
            return rows >= 0 && rows < matrix.GetLength(0) && columns >= 0 && columns < matrix.GetLength(1);
        }

        private static void FindMiner()
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    if (matrix[rows, columns] == "s")
                    {
                        row = rows;
                        column = columns;
                        return;
                    }
                }
            }
        }
    }
}

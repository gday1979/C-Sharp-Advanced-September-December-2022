using System;

namespace _02
{
    class Program
    {
        static char[][] room;
        static void Main(string[] args)
        {
            int countOfRow = int.Parse(Console.ReadLine());
            room = new char[countOfRow][];

            for (int row = 0; row < countOfRow; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
            }

            char[] commands = Console.ReadLine().ToCharArray();

            int rowNikoladze = FindNikoladze();

            for (int counter = 0; counter < commands.Length; counter++)
            {
                string message = MoveEnemy();

                if (message != "no")
                {
                    Console.WriteLine(message);
                    PrintRoom();
                    return;
                }

                message = MovePlayer(commands[counter], rowNikoladze);

                if (message != "no")
                {
                    Console.WriteLine(message);
                    PrintRoom();
                    return;
                }

            }

        }

        private static int FindNikoladze()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int column = 0; column < room[row].Length; column++)
                {
                    if (room[row][column] == 'N')
                    {
                        return row;
                    }
                }
            }
            return 0;
        }

        private static string MovePlayer(char command, int rowNikoladze)
        {
            int[] positionSam = FindSam();
            int row = positionSam[0];
            int column = positionSam[1];
            string message = string.Empty;

            switch (command)
            {
                case 'W':
                    message = "no";
                    break;

                case 'U':
                    if (row - 1 == rowNikoladze)
                    {
                        message = "Nikoladze killed!";
                        for (int col = 0; col < room[rowNikoladze].Length; col++)
                        {
                            if (room[rowNikoladze][col] == 'N')
                            {
                                room[rowNikoladze][col] = 'X';
                            }
                        }
                        room[row - 1][column] = 'S';
                        room[row][column] = '.';
                    }
                    else
                    {
                        message = "no";
                        room[row - 1][column] = 'S';
                        room[row][column] = '.';
                    }
                    break;


                case 'D':
                    if (row + 1 == rowNikoladze)
                    {
                        message = "Nikoladze killed!";
                        for (int col = 0; col < room[rowNikoladze].Length; col++)
                        {
                            if (room[rowNikoladze][col] == 'N')
                            {
                                room[rowNikoladze][col] = 'X';
                            }
                        }
                        room[row + 1][column] = 'S';
                        room[row][column] = '.';
                    }
                    else
                    {
                        message = "no";
                        room[row + 1][column] = 'S';
                        room[row][column] = '.';
                    }
                    break;

                case 'L':
                    room[row][column - 1] = 'S';
                    room[row][column] = '.';
                    message = "no";
                    break;

                case 'R':
                    room[row][column + 1] = 'S';
                    room[row][column] = '.';
                    message = "no";
                    break;
            }

            return message;


        }

        private static int[] FindSam()
        {
            int[] rowAndColumn = new int[2];
            for (int row = 0; row < room.Length; row++)
            {
                for (int column = 0; column < room[row].Length; column++)
                {
                    if (room[row][column] == 'S')
                    {
                        rowAndColumn[0] = row;
                        rowAndColumn[1] = column;
                        return rowAndColumn;
                    }
                }
            }
            return rowAndColumn;
        }

        private static void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int column = 0; column < room[row].Length; column++)
                {
                    Console.Write(room[row][column]);
                }
                Console.WriteLine();
            }
        }

        private static string MoveEnemy()
        {
            string message = string.Empty;
            bool isDied = false;

            for (int row = 0; row < room.Length; row++)
            {
                for (int column = 0; column < room[row].Length; column++)
                {
                    if (room[row][column] == 'b')
                    {
                        if (column == room[row].Length - 1)
                        {
                            room[row][column] = 'd';
                            for (int counter = room[row].Length - 2; counter >= 0; counter--)
                            {
                                if (room[row][counter] == 'S')
                                {
                                    room[row][counter] = 'X';
                                    message = $"Sam died at {row}, {counter}";
                                    isDied = true;
                                    break;
                                }
                            }
                            break;
                        }
                        else
                        {
                            for (int counter = column; counter < room[row].Length; counter++)
                            {
                                if (room[row][counter] == 'S')
                                {
                                    room[row][counter] = 'X';
                                    message = $"Sam died at {row}, {counter}";
                                    isDied = true;
                                    break;
                                }
                            }
                            room[row][column] = '.';
                            room[row][column + 1] = 'b';
                            break;
                        }
                    }
                    else if (room[row][column] == 'd')
                    {
                        if (column == 0)
                        {
                            room[row][column] = 'b';
                            for (int counter = 1; counter < room[row].Length; counter++)
                            {
                                if (room[row][counter] == 'S')
                                {
                                    room[row][counter] = 'X';
                                    message = $"Sam died at {row}, {counter}";
                                    isDied = true;
                                    break;
                                }
                            }
                            break;
                        }
                        else
                        {
                            for (int counter = column; counter >= 0; counter--)
                            {
                                if (room[row][counter] == 'S')
                                {
                                    room[row][counter] = 'X';
                                    message = $"Sam died at {row}, {counter}";
                                    isDied = true;
                                    break;
                                }
                            }
                            room[row][column] = '.';
                            room[row][column - 1] = 'd';
                            break;
                        }
                    }

                    if (isDied)
                    {
                        return message;
                    }
                }
            }

            return "no";
        }
    }
}

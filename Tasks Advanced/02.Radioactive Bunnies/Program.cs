using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] colsRows = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int rows = colsRows[0];
            int cols = colsRows[1];
            int currentRow = 0;
            int currentCol = 0;

            List<int> BunnyRows = new List<int>();
            List<int> BunnyCols = new List<int>();

            char[][] board = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                board[i] = new char[cols];
                for (int j = 0; j < cols; j++)
                {
                    board[i][j] = input[j];
                    if (board[i][j] == 'B')
                    {
                        BunnyRows.Add(i);
                        BunnyCols.Add(j);
                    }
                    if (board[i][j] == 'P')
                    {
                        currentRow = i;
                        currentCol = j;
                    }
                }
            }
            bool win = false;
            bool loose = false;
            string command = Console.ReadLine();

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i].ToString() == "U")
                {
                    if (currentRow - 1 >= 0)
                    {
                        if (Convert.ToChar(board[currentRow - 1][currentCol]) == 'B')
                        {
                            board[currentRow][currentCol] = 'B';
                            loose = true;
                            currentRow--;
                        }
                        else
                        {
                            board[currentRow - 1][currentCol] = board[currentRow][currentCol];
                            board[currentRow][currentCol] = '.';
                            currentRow--;
                        }
                    }
                    else
                    {
                        win = true;
                        board[currentRow][currentCol] = '.';
                    }
                }

                if (command[i].ToString() == "D")
                {
                    if (currentRow + 1 < rows)
                    {
                        if (Convert.ToChar(board[currentRow + 1][currentCol]) == 'B')
                        {
                            board[currentRow][currentCol] = 'B';
                            loose = true;
                            currentRow++;
                        }
                        else
                        {
                            board[currentRow + 1][currentCol] = board[currentRow][currentCol];
                            board[currentRow][currentCol] = '.';
                            currentRow++;
                        }
                    }
                    else
                    {
                        win = true;
                        board[currentRow][currentCol] = '.';
                    }
                }

                if (command[i].ToString() == "L")
                {
                    if (currentCol - 1 >= 0)
                    {
                        if (Convert.ToChar(board[currentRow][currentCol - 1]) == 'B')
                        {
                            board[currentRow][currentCol] = 'B';
                            loose = true;
                            currentCol--;
                        }
                        else
                        {
                            board[currentRow][currentCol - 1] = board[currentRow][currentCol];
                            board[currentRow][currentCol] = '.';
                            currentCol--;
                        }
                    }
                    else
                    {
                        win = true;
                        board[currentRow][currentCol] = '.';
                    }
                }

                if (command[i].ToString() == "R")
                {
                    if (currentCol + 1 < cols)
                    {
                        if (Convert.ToChar(board[currentRow][currentCol + 1]) == 'B')
                        {
                            board[currentRow][currentCol] = 'B';
                            loose = true;
                            currentCol++;
                        }
                        else
                        {
                            board[currentRow][currentCol + 1] = board[currentRow][currentCol];
                            board[currentRow][currentCol] = '.';
                            currentCol++;
                        }
                    }
                    else
                    {
                        win = true;
                        board[currentRow][currentCol] = '.';
                    }
                }

                //Spreding bunnys
                for (int j = 0; j < BunnyRows.Count; j++)
                {
                    //down
                    if (BunnyRows[j] + 1 < rows)
                    {
                        if (Convert.ToChar(board[BunnyRows[j] + 1][BunnyCols[j]]) == '.')
                        {
                            board[BunnyRows[j] + 1][BunnyCols[j]] = 'B';
                        }
                        else if (Convert.ToChar(board[BunnyRows[j] + 1][BunnyCols[j]]) == 'P')
                        {
                            if (win)
                            {

                            }
                            else
                            {
                                loose = true;
                                board[currentRow][currentCol] = 'B';
                            }
                        }
                    }
                    //up
                    if (BunnyRows[j] - 1 >= 0)
                    {
                        if (Convert.ToChar(board[BunnyRows[j] - 1][BunnyCols[j]]) == '.')
                        {
                            board[BunnyRows[j] - 1][BunnyCols[j]] = 'B';
                        }
                        else if (Convert.ToChar(board[BunnyRows[j] - 1][BunnyCols[j]]) == 'P')
                        {
                            if (win)
                            {

                            }
                            else
                            {
                                loose = true;
                                board[currentRow][currentCol] = 'B';
                            }
                        }
                    }
                    //left
                    if (BunnyCols[j] - 1 >= 0)
                    {
                        if (Convert.ToChar(board[BunnyRows[j]][BunnyCols[j] - 1]) == '.')
                        {
                            board[BunnyRows[j]][BunnyCols[j] - 1] = 'B';
                        }
                        else if (Convert.ToChar(board[BunnyRows[j]][BunnyCols[j] - 1]) == 'P')
                        {
                            if (win)
                            {

                            }
                            else
                            {
                                loose = true;
                                board[currentRow][currentCol] = 'B';
                            }
                        }
                    }
                    //right
                    if (BunnyCols[j] + 1 < cols)
                    {
                        if (Convert.ToChar(board[BunnyRows[j]][BunnyCols[j] + 1]) == '.')
                        {
                            board[BunnyRows[j]][BunnyCols[j] + 1] = 'B';
                        }
                        else if (Convert.ToChar(board[BunnyRows[j]][BunnyCols[j] + 1]) == 'P')
                        {
                            if (win)
                            {

                            }
                            else
                            {
                                loose = true;
                                board[currentRow][currentCol] = 'B';
                            }
                        }
                    }
                }
                BunnyRows.Clear();
                BunnyCols.Clear();
                //Generating Bunnys coordinates
                for (int matrixRow = 0; matrixRow < rows; matrixRow++)
                {
                    for (int matrixCol = 0; matrixCol < cols; matrixCol++)
                    {
                        if (board[matrixRow][matrixCol] == 'B')
                        {
                            BunnyRows.Add(matrixRow);
                            BunnyCols.Add(matrixCol);
                        }
                    }
                }

                if (win || loose)
                {
                    break;
                }
            }
            foreach (var row in board)
            {
                foreach (var col in row)
                {
                    Console.Write(col);
                }
                Console.WriteLine();
            }
            if (win)
            {
                Console.WriteLine("won: {0} {1}", currentRow, currentCol);
            }
            else
            {
                Console.WriteLine("dead: {0} {1}", currentRow, currentCol);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int rows = Convert.ToInt32(input[0]);
            int cols = Convert.ToInt32(input[1]);

            string snake = Console.ReadLine();

            string[][] matrix = new string[rows][];
            int k = 0;
            for (int i = rows - 1; i >= 0; i--)
            {
                matrix[i] = new string[cols];
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (k == snake.Length)
                    {
                        k = 0;
                    }
                    matrix[i][j] = snake[k].ToString();
                    k++;
                }
                if (i == 0)
                {
                    break;
                }
                i--;
                matrix[i] = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    if (k == snake.Length)
                    {
                        k = 0;
                    }
                    matrix[i][j] = snake[k].ToString();
                    k++;
                }
            }

            string[] impact = Console.ReadLine().Split();
            int impactRow = Convert.ToInt32(impact[0]);
            int impactCol = Convert.ToInt32(impact[1]);
            int impactRadius = Convert.ToInt32(impact[2]);

            List<int> targetRow = new List<int>();
            List<int> targetCol = new List<int>();
            targetRow.Add(impactRow);
            targetCol.Add(impactCol);

            //impact
            matrix[impactRow][impactCol] = " ";

            //Radius
            for (int i = 0; i < impactRadius; i++)
            {
                for (int j = 0; j < targetRow.Count; j++)
                {
                    //left
                    if (targetCol[j] - 1 >= 0)
                    {
                        matrix[targetRow[j]][targetCol[j] - 1] = " ";
                    }
                    //right
                    if (targetCol[j] + 1 < cols)
                    {
                        matrix[targetRow[j]][targetCol[j] + 1] = " ";
                    }
                    //down
                    if (targetRow[j] + 1 < rows)
                    {
                        matrix[targetRow[j] + 1][targetCol[j]] = " ";
                    }
                    //up
                    if (targetRow[j] - 1 >= 0)
                    {
                        matrix[targetRow[j] - 1][targetCol[j]] = " ";
                    }
                    //diagonal
                    if (i == 2)
                    {
                        if (impactRow - i >= 0 && impactCol - i >= 0)
                        {
                            matrix[impactRow - i][impactCol - i] = " ";
                        }
                        if (impactRow + i < rows && impactCol + i < cols)
                        {
                            matrix[impactRow + i][impactCol + i] = " ";
                        }
                        if (impactRow - i >= 0 && impactCol + i < cols)
                        {
                            matrix[impactRow - i][impactCol + i] = " ";
                        }
                        if (impactRow + 1 < rows && impactCol - 1 >= 0)
                        {
                            matrix[impactRow + i][impactCol - i] = " ";
                        }
                    }
                }
                targetRow.Clear();
                targetCol.Clear();
                //generating coordinates
                for (int matrixRow = 0; matrixRow < rows; matrixRow++)
                {
                    for (int matrixCol = 0; matrixCol < cols; matrixCol++)
                    {
                        if (matrix[matrixRow][matrixCol] == " ")
                        {
                            targetRow.Add(matrixRow);
                            targetCol.Add(matrixCol);
                        }
                    }
                }
            }

            //falling down
            bool isSwapped;
            string swap;
            for (int i = 0; i < cols; i++)
            {
                isSwapped = false;
                for (int j = 0; j < rows - 1; j++)
                {
                    if (matrix[j][i] != " " && matrix[j + 1][i] == " ")
                    {
                        swap = " ";
                        matrix[j + 1][i] = matrix[j][i];
                        matrix[j][i] = swap;
                        isSwapped = true;
                    }
                }
                if (isSwapped)
                {
                    i--;
                }
            }
            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    Console.Write("{0}", col);
                }
                Console.WriteLine();
            }
        }
    }
}

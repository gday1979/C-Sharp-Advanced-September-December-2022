using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Plus_Remove
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = new List<string>();
            string input = Console.ReadLine();
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            //reading the matrix
            while (input != "END")
            {
                data.Add(input);
                input = Console.ReadLine();
            }
            char[][] matrix = new char[data.Count][];
            for (int i = 0; i < data.Count; i++)
            {
                matrix[i] = new char[data[i].Length];
                for (int j = 0; j < data[i].Length; j++)
                {
                    matrix[i][j] = Convert.ToChar(data[i][j].ToString());
                }
            }
            bool up = false;
            bool down = false;
            bool left = false;
            bool right = false;

            //finding shape coordinates
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    try
                    {
                        if (Char.ToLower(matrix[i][j]) == Char.ToLower(matrix[i][j + 1]))
                        {
                            right = true;
                        }
                        if (Char.ToLower(matrix[i][j]) == Char.ToLower(matrix[i][j - 1]))
                        {
                            left = true;
                        }
                        if (Char.ToLower(matrix[i][j]) == Char.ToLower(matrix[i - 1][j]))
                        {
                            up = true;
                        }
                        if (Char.ToLower(matrix[i][j]) == Char.ToLower(matrix[i + 1][j]))
                        {
                            down = true;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                    if (down && up && left && right)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                    right = false;
                    left = false;
                    up = false;
                    down = false;
                }
            }

            //removing shapes
            for (int i = 0; i < rows.Count; i++)
            {
                matrix[rows[i]][cols[i]] = ' ';
                matrix[rows[i]][cols[i] + 1] = ' ';
                matrix[rows[i]][cols[i] - 1] = ' ';
                matrix[rows[i] + 1][cols[i]] = ' ';
                matrix[rows[i] - 1][cols[i]] = ' ';
            }

            //formatting the matrix
            bool isSwapped = false;
            char swap;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    if (matrix[i][j] == ' ' && matrix[i][j + 1] != ' ')
                    {
                        swap = matrix[i][j + 1];
                        matrix[i][j] = swap;
                        matrix[i][j + 1] = ' ';
                        isSwapped = true;
                    }
                }
                if (isSwapped)
                {
                    i--;
                }
                isSwapped = false;
            }

            //printing the matrix
            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    Console.Write(col);
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string rotate = Console.ReadLine();
            int startIndex = rotate.IndexOf('(');
            int endIndex = rotate.IndexOf(')');
            int degree = Convert.ToInt32(rotate.Substring(startIndex + 1, endIndex - startIndex - 1));
            List<string> sequence = new List<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                sequence.Add(input);
                input = Console.ReadLine();
            }

            string[][] matrix = new string[sequence.Count][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new string[sequence[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = sequence[i][j].ToString();
                }
            }
            if (degree > 360)
            {
                int count = degree / 90;
                degree = 0;
                for (int i = 0; i < count; i++)
                {
                    if (degree == 360)
                    {
                        degree = 0;
                    }
                    degree += 90;
                }
            }

            switch (degree)
            {
                case 0:
                    break;
                case 90:
                    matrix = Rotate90(matrix);
                    break;
                case 180:
                    matrix = Rotate180(matrix);
                    break;
                case 270:
                    matrix = Rotate270(matrix);
                    break;
                case 360:
                    break;
            }

            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    Console.Write(col);
                }
                Console.WriteLine();
            }

        }

        private static string[][] Rotate270(string[][] matrix)
        {
            int maxCount = 0;
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                count = matrix[i].Length;
                if (count > maxCount)
                {
                    maxCount = count;
                }
            }
            string[][] xaxa = new string[maxCount][];
            string sequnce = null;
            int xaxaCol = 0;
            int sequenceRow = xaxa.Length - 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                sequnce = string.Join("", matrix[i]);
                for (int j = 0; j < xaxa.Length; j++)
                {
                    try
                    {
                        if (i != 0)
                        {
                            xaxa[j][xaxaCol] = sequnce[sequenceRow].ToString();
                        }
                        else
                        {
                            xaxa[j] = new string[matrix.Length];
                            xaxa[j][xaxaCol] = sequnce[sequenceRow].ToString();
                        }

                    }
                    catch (Exception)
                    {
                        xaxa[j][xaxaCol] = " ";
                    }
                    sequenceRow--;
                }
                sequenceRow = xaxa.Length - 1;
                xaxaCol++;
            }
            return xaxa;
        }

        private static string[][] Rotate180(string[][] matrix)
        {
            string[][] xaxa = new string[matrix.Length][];
            int row = 0;
            int col = 0;
            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                xaxa[row] = new string[matrix[i].Length];
                col = 0;
                for (int j = matrix[i].Length - 1; j >= 0; j--)
                {
                    xaxa[row][col] = matrix[i][j];
                    col++;
                }
                row++;
            }
            return xaxa;
        }

        private static string[][] Rotate90(string[][] matrix)
        {
            int maxCount = 0;
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                count = matrix[i].Length;
                if (count > maxCount)
                {
                    maxCount = count;
                }
            }
            string[][] xaxa = new string[maxCount][];
            string sequnce = null;
            int xaxaCol = 0;
            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                sequnce = string.Join("", matrix[i]);

                for (int j = 0; j < xaxa.Length; j++)
                {
                    try
                    {
                        if (i != matrix.Length - 1)
                        {
                            xaxa[j][xaxaCol] = sequnce[j].ToString();
                        }
                        else
                        {
                            xaxa[j] = new string[matrix.Length];
                            xaxa[j][xaxaCol] = sequnce[j].ToString();
                        }

                    }
                    catch (Exception)
                    {
                        xaxa[j][xaxaCol] = " ";
                    }

                }
                xaxaCol++;
            }
            return xaxa;
        }
    }
}

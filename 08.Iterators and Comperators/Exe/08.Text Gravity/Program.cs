using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _08.Text_Gravity
{
    class Program
    {
        static void Main(string[] args)
        {
            int col = Convert.ToInt32(Console.ReadLine());
            string input = Console.ReadLine();
            int inputLenght = input.Length;
            int row = 0;
            if (inputLenght % col == 0)
            {
                row = inputLenght / col;
            }
            else
            {
                row = (inputLenght / col) + 1;
            }
            int k = 0;
            string[][] matrix = new string[row][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new string[col];
                for (int j = 0; j < col; j++)
                {
                    if (k >= inputLenght)
                    {
                        matrix[i][j] = " ";
                    }
                    else
                    {
                        matrix[i][j] = input[k].ToString();
                    }
                    k++;
                }
            }
            bool isSwap = false;
            string swapped = null;
            for (int i = 0; i < col; i++)
            {
                for (int j = matrix.Length - 1; j > 0; j--)
                {
                    if (matrix[j][i] == " " && matrix[j - 1][i] != " ")
                    {
                        swapped = matrix[j - 1][i];
                        matrix[j][i] = swapped;
                        matrix[j - 1][i] = " ";
                        isSwap = true;
                    }
                }
                if (isSwap)
                {
                    i--;
                }
                isSwap = false;
            }
            Console.Write("<table>");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            Console.Write("<tr><td>{0}", SecurityElement.Escape(matrix[i][j]));
                        }
                        else
                        {
                            Console.Write("</td></tr><tr><td>{0}", SecurityElement.Escape(matrix[i][j]));
                        }
                    }
                    else
                    {
                        Console.Write("</td><td>{0}", SecurityElement.Escape(matrix[i][j]));
                    }
                }
            }
            Console.Write("</td></tr></table>");
        }
    }
}
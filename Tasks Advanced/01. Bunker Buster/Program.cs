using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BunkerBuster
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);
            int allCells = row * col;
            int[][] field = new int[row][];
            for (int i = 0; i < row; i++)
            {
                int[] input2 = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                field[i] = new int[col];
                for (int j = 0; j < col; j++)
                {
                    field[i][j] = input2[j];
                }
            }

            bool up = false;
            bool down = false;
            bool left = false;
            bool right = false;
            string command = Console.ReadLine();
            while (command != "cease fire!")
            {
                string[] elements = command.Trim().Split();
                int targetRow = Convert.ToInt32(elements[0]);
                int targetCol = Convert.ToInt32(elements[1]);
                int firePower = Convert.ToChar(elements[2]);
                int damageToCells;
                field[targetRow][targetCol] -= firePower;
                if (firePower % 2 == 0)
                {
                    damageToCells = firePower / 2;
                }
                else
                {
                    damageToCells = (firePower / 2) + 1;
                }
                if (targetCol - 1 >= 0)
                {
                    field[targetRow][targetCol - 1] -= damageToCells;
                    left = true;
                }
                if (targetCol + 1 < col)
                {
                    field[targetRow][targetCol + 1] -= damageToCells;
                    right = true;
                }
                if (targetRow - 1 >= 0)
                {
                    field[targetRow - 1][targetCol] -= damageToCells;
                    up = true;
                }
                if (targetRow + 1 < row)
                {
                    field[targetRow + 1][targetCol] -= damageToCells;
                    down = true;
                }
                if (left && up)
                {
                    field[targetRow - 1][targetCol - 1] -= damageToCells;
                }
                if (right && up)
                {
                    field[targetRow - 1][targetCol + 1] -= damageToCells;
                }
                if (left && down)
                {
                    field[targetRow + 1][targetCol - 1] -= damageToCells;
                }
                if (right && down)
                {
                    field[targetRow + 1][targetCol + 1] -= damageToCells;
                }
                command = Console.ReadLine();
                up = false;
                down = false;
                right = false;
                left = false;
            }

            int destroyedCells = 0;
            foreach (var rows in field)
            {
                foreach (var item in rows)
                {
                    if (item <= 0)
                    {
                        destroyedCells++;
                    }
                }
            }
            Console.WriteLine("Destroyed bunkers: {0}", destroyedCells);
            Console.WriteLine("Damage done: {0:P1}", (double)destroyedCells / allCells);
        }
    }
}

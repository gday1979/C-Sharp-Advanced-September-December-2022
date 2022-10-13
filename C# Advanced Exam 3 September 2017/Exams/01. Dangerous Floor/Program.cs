using System;

namespace _01
{
    class Program
    {
        static string[,] board;
        static void Main(string[] args)
        {
            board = new string[8, 8];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string[] currRow = Console.ReadLine().Split(",");
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    board[row, column] = currRow[column];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split("-");
                char[] symbols = tokens[0].ToCharArray();
                char[] destination = tokens[1].ToCharArray();

                MoveFigure(symbols, destination);

            }
        }

        private static void MoveFigure(char[] symbols, char[] destination)
        {
            int positionRow = int.Parse(symbols[1].ToString());
            int positionColumn = int.Parse(symbols[2].ToString());
            int destinationRow = int.Parse(destination[0].ToString());
            int destinationColumn = int.Parse(destination[1].ToString());

            if ((IsThereFigure(symbols)) == false)
            {
                Console.WriteLine("There is no such a piece!");
                return;
            }

            if (IsValidMove(symbols, destination) == false)
            {
                Console.WriteLine("Invalid move!");
                return;
            }

            if (IsOnBoard(destination[0], destination[1]) == false)
            {
                Console.WriteLine("Move go out of board!");
                return;
            }

            board[positionRow, positionColumn] = "x";
            board[destinationRow, destinationColumn] = symbols[0].ToString();
        }

        private static bool IsValidMove(char[] symbols, char[] destination)
        {
            if (IsOnBoard(destination[0], destination[1]))
            {
                int positionRow = int.Parse(symbols[1].ToString());
                int positionColumn = int.Parse(symbols[2].ToString());
                int destinationRow = int.Parse(destination[0].ToString());
                int destinationColumn = int.Parse(destination[1].ToString());

                switch (symbols[0])
                {
                    case 'P':
                        if (positionRow - 1 == destinationRow && positionColumn == destinationColumn)
                        {
                            return true;
                        }
                        return false;
                    case 'K':
                        if (destinationColumn >= positionColumn - 1 && destinationColumn <= positionColumn + 1
                            && destinationRow >= positionRow - 1 && destinationRow <= positionRow + 1 &&
                            destinationRow != positionRow && destinationColumn != positionColumn)
                        {
                            return true;
                        }
                        return false;
                    case 'R':
                        if (destinationColumn == positionColumn || destinationRow == positionRow)
                        {
                            return true;
                        }
                        return false;
                    case 'B':
                        return destinationColumn + destinationRow == positionColumn + positionRow;
                    case 'Q':
                        return destinationColumn == positionColumn || destinationRow == positionRow ||
                            destinationColumn + destinationRow == positionColumn + positionRow;
                    default:
                        throw new NotImplementedException();
                }


            }
            return true;
        }

        private static bool IsThereFigure(char[] symbols)
        {
            if (IsOnBoard(symbols[1], symbols[2]))
            {

                int row = int.Parse(symbols[1].ToString());
                int column = int.Parse(symbols[2].ToString());
                string figure = symbols[0].ToString();

                return board[row, column] == figure;
            }
            return true;
        }

        private static bool IsOnBoard(char symbol1, char symbol2)
        {
            int row = int.Parse(symbol1.ToString());
            int column = int.Parse(symbol2.ToString());

            return row >= 0 && row < board.GetLength(0) && column >= 0 && column < board.GetLength(1);
        }
    }
}

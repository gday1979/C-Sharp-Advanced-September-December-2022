using System;



namespace _02_KnightGame
{
    class Program
    {
        static char[][] board;
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            board = new char[dimensions][];

            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine().ToCharArray();
            }

            int countOfRemoveKnights = 0;
            int bestAttakedPositions = 0;
            int rowIndex = 0;
            int columnIndex = 0;


            do
            {
                if (bestAttakedPositions > 0)
                {
                    board[rowIndex][columnIndex] = '0';
                    bestAttakedPositions = 0;
                    countOfRemoveKnights++;
                }

                int currentAttakedPosition = 0;
                for (int row = 0; row < board.Length; row++)
                {
                    for (int column = 0; column < board[row].Length; column++)
                    {
                        if (board[row][column] == 'K')
                        {
                            currentAttakedPosition = CalculateAttakedPositions(row, column);
                            if (currentAttakedPosition > bestAttakedPositions)
                            {
                                bestAttakedPositions = currentAttakedPosition;
                                rowIndex = row;
                                columnIndex = column;
                            }
                        }
                    }
                }

            } while (bestAttakedPositions > 0);


            Console.WriteLine(countOfRemoveKnights);

        }

        private static int CalculateAttakedPositions(int row, int column)
        {
            int attakedPositions = 0;

            if (IsPositionAttaked(row - 2, column - 1)) attakedPositions++;
            if (IsPositionAttaked(row - 2, column + 1)) attakedPositions++;
            if (IsPositionAttaked(row - 1, column - 2)) attakedPositions++;
            if (IsPositionAttaked(row - 1, column + 2)) attakedPositions++;
            if (IsPositionAttaked(row + 1, column - 2)) attakedPositions++;
            if (IsPositionAttaked(row + 1, column + 2)) attakedPositions++;
            if (IsPositionAttaked(row + 2, column - 1)) attakedPositions++;
            if (IsPositionAttaked(row + 2, column + 1)) attakedPositions++;

            return attakedPositions;
        }


        private static bool IsPositionAttaked(int row, int column)
        {
            return IsWithInBoard(row, column) && board[row][column] == 'K';
        }
        private static bool IsWithInBoard(int row, int column)
        {
            Func<int, bool> func = x => x >= 0 && x < board[0].Length;
            return func(row) && func(column);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int[][] parking = new int[rows][];
            bool notFoundDestination = false;
            for (int i = 0; i < rows; i++)
            {
                parking[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    parking[i][j] = 0;
                }
            }

            int destinationTravelled = 1;
            string input2 = Console.ReadLine();

            while (input2 != "stop")
            {
                string[] coordinates = input2.Split();
                int CarCurrentRow = int.Parse(coordinates[0]);
                int CarCurrentCol = 0;
                int DestinationRow = int.Parse(coordinates[1]);
                int DestinationCol = int.Parse(coordinates[2]);
                if (DestinationRow > CarCurrentRow)
                {
                    for (int i = CarCurrentRow; i < DestinationRow; i++)
                    {
                        destinationTravelled++;
                    }
                }
                else if (DestinationRow < CarCurrentRow)
                {
                    for (int i = DestinationRow; i < CarCurrentRow; i++)
                    {
                        destinationTravelled++;
                    }
                }
                else if (DestinationRow == CarCurrentRow)
                {
                    destinationTravelled = 1;
                }

                if (parking[DestinationRow][DestinationCol] == 1)
                {
                    for (int i = 1; i < 20000; i++)
                    {
                        if (DestinationCol - i > 0)
                        {
                            if (parking[DestinationRow][DestinationCol - i] == 0)
                            {
                                DestinationCol = DestinationCol - i;
                                break;
                            }
                        }
                        if (DestinationCol + i < cols)
                        {
                            if (parking[DestinationRow][DestinationCol + i] == 0)
                            {
                                DestinationCol = DestinationCol + i;
                                break;
                            }
                        }
                        if (DestinationCol - i <= 0 && DestinationCol + i >= cols)
                        {
                            Console.WriteLine("Row {0} full", DestinationRow);
                            notFoundDestination = true;
                            break;
                        }
                    }
                }
                parking[DestinationRow][DestinationCol] = 1;
                for (int i = CarCurrentCol; i < DestinationCol; i++)
                {
                    destinationTravelled++;
                }
                if (!notFoundDestination)
                {
                    Console.WriteLine(destinationTravelled);
                }
                notFoundDestination = false;
                input2 = Console.ReadLine();
                destinationTravelled = 1;
            }
        }
    }
}

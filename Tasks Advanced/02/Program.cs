using System.Linq;
using System;



namespace _02
{
    class Program
    {
        static string[,] parking;
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            parking = new string[size[0] + size[0] - 1, size[1] + 2];

            int entryinput = int.Parse(Console.ReadLine());
            int entryRow = entryinput + (entryinput - 1);
            bool isParking = true;
            int step = 0;
            string parkingSpace = string.Empty;

            while (isParking)
            {
                string[] parkNumbers = Console.ReadLine().Split();

                string number = parkNumbers[entryinput - 1];
                char[] parkNumber = parkNumbers[entryinput - 1].ToCharArray();
                int rowinput = int.Parse(parkNumber[1].ToString());
                int row = rowinput + (rowinput - 2);
                int column = char.ToUpper(parkNumber[0]) - 64;

                int currStep = MoveCar(row, column, entryRow);

                if (parkNumbers.Contains(number))
                {
                    int index = Array.FindIndex(parkNumbers, x => x == number);
                    if (index == entryinput - 1)
                    {
                        index = Array.FindLastIndex(parkNumbers, x => x == number);
                    }

                    char[] parkNumberDrive = parkNumbers[index].ToCharArray();
                    int rowDriveInput = int.Parse(parkNumber[1].ToString());
                    int rowDrive = rowDriveInput + (rowDriveInput - 2);
                    int columnDrive = char.ToUpper(parkNumber[0]) - 64;

                    int currStepDrive = MoveCar(row, column, index + (index - 1));

                    if (currStep > currStepDrive)
                    {
                        currStep *= 2;
                    }
                    else
                    {
                        isParking = false;
                        parkingSpace = parkNumbers[entryinput - 1];
                    }

                }
                else
                {
                    isParking = false;
                    parkingSpace = parkNumbers[entryinput - 1];
                }

                step += currStep;
            }

            Console.WriteLine($"Parked successfully at {parkingSpace}.");
            Console.WriteLine($"Total Distance Passed: {step}");

        }

        private static int MoveCar(int row, int column, int entryRow)
        {
            int currStep = 0;
            int rowCar = entryRow;
            int columnCar = 0;
            bool isRight = true;

            for (int counterRow = rowCar; counterRow < parking.GetLength(0); counterRow += 2)
            {
                if (counterRow != rowCar)
                {
                    currStep += 2;
                }

                int min = 0;
                int max = 0;

                if (isRight)
                {
                    min = 0;
                    max = parking.GetLength(1);
                }
                else
                {
                    min = parking.GetLength(1) - 1;
                    max = -1;
                }

                for (int counterCol = min; counterCol < max;)
                {
                    if ((counterCol == column) && (counterRow == row + 1 || counterRow == row - 1))
                    {
                        return currStep;
                    }

                    currStep++;

                    if (isRight)
                    {
                        counterCol++;
                    }
                    else
                    {
                        counterCol--;
                    }
                }

                isRight = !isRight;

            }

            //while (((columnCar == column) && (rowCar == row - 1 || rowCar == row + 1)) == false)
            //{
            //    if (columnCar != parking.GetLength(1) - 1 && columnCar != 0)
            //    {
            //        if (isRight)
            //        {
            //            rowCar++;
            //            currStep++;
            //        }
            //        else
            //        {
            //            rowCar--;
            //            currStep++;
            //        }


            //    }
            //    else
            //    {
            //        isRight = !isRight;

            //        if (row < rowCar)
            //        {
            //            rowCar -= 2;
            //            currStep += 2;
            //        }
            //        else if (row > rowCar)
            //        {
            //            rowCar += 2;
            //            currStep += 2;
            //        }

            //    }
            //}

            return currStep;
        }
    }
}

using System;

class Officer
{
    public int RowIndex { get; set; }
    public int ColIndex { get; set; }
    public int GoldSpent { get; set; }
    public bool HasLeftTheArmory { get; set; }

    public Officer(int row, int col)
    {
        this.RowIndex = row;
        this.ColIndex = col;
        this.GoldSpent = 0;
        this.HasLeftTheArmory = false;
    }

    public void Move(int matrixSize)
    {
        string command = Console.ReadLine();
        if (command == "up")
            this.RowIndex--;
        else if (command == "down")
            this.RowIndex++;
        else if (command == "left")
            this.ColIndex--;
        else if (command == "right")
            this.ColIndex++;

        if (this.RowIndex < 0 || this.RowIndex == matrixSize ||
            this.ColIndex < 0 || this.ColIndex == matrixSize)
            this.HasLeftTheArmory = true;
    }
}

internal class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[,] armory = GetArmoryData(size);
        int[] startingPosition = GetCoordinatesOfTheOfficer(armory);
        Officer officer = new Officer(startingPosition[0], startingPosition[1]);

        while (officer.GoldSpent < 65)
        {
            officer.Move(size);
            if (officer.HasLeftTheArmory) break;

            char currentChar = armory[officer.RowIndex, officer.ColIndex];
            if (currentChar >= '0' && currentChar <= '9')
            {
                officer.GoldSpent += int.Parse(currentChar.ToString());
                armory[officer.RowIndex, officer.ColIndex] = '-';
            }
            else if (currentChar == 'M')
                TeleportToOtherMirror(officer, armory);
        }
        PrintOutput(officer, armory);
    }

    static char[,] GetArmoryData(int size)
    {
        char[,] armory = new char[size, size];
        for (int row = 0; row < size; row++)
        {
            string line = Console.ReadLine();
            for (int col = 0; col < size; col++)
            {
                armory[row, col] = line[col];
            }
        }
        return armory;
    }

    static int[] GetCoordinatesOfTheOfficer(char[,] armory)
    {
        int[] coordinates = new int[2];
        for (int row = 0; row < armory.GetLength(0); row++)
        {
            for (int col = 0; col < armory.GetLength(1); col++)
            {
                if (armory[row, col] == 'A')
                {
                    coordinates[0] = row;
                    coordinates[1] = col;
                    armory[row, col] = '-';
                    return coordinates;
                }
            }
        }
        return coordinates;
    }

    static void TeleportToOtherMirror(Officer officer, char[,] armory)
    {
        armory[officer.RowIndex, officer.ColIndex] = '-';
        for (int row = 0; row < armory.GetLength(0); row++)
            for (int col = 0; col < armory.GetLength(1); col++)
                if (armory[row, col] == 'M')
                {
                    officer.RowIndex = row;
                    officer.ColIndex = col;
                    armory[row, col] = '-';
                    return;
                }
    }

    static void PrintOutput(Officer officer, char[,] armory)
    {
        if (officer.HasLeftTheArmory)
        {
            Console.WriteLine("I do not need more swords!");
        }
        else
        {
            Console.WriteLine("Very nice swords, I will come back for more!");
            armory[officer.RowIndex, officer.ColIndex] = 'A';
        }
        Console.WriteLine($"The king paid {officer.GoldSpent} gold coins.");

        for (int row = 0; row < armory.GetLength(0); row++)
        {
            for (int col = 0; col < armory.GetLength(1); col++)
            {
                Console.Write(armory[row, col]);
            }
            Console.WriteLine();
        }
    }
}

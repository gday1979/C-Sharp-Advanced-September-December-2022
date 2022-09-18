using System;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int[][] arrays=new int[n][];
            for (int i = 0; i < n; i++)
            {
                var line=Console.ReadLine();
                var lineParts = line.Split(" ");
                arrays[i]=new int[lineParts.Length];
                for (int j = 0; j <lineParts.Length ; j++)
                {
                    arrays[i][j] = int.Parse(lineParts[j]);
                }
            }
            while (true)
            {
                var line = Console.ReadLine();
                var commandParts = line.Split(" ");
                var commandName=commandParts[0];
                if (commandName=="END")
                {
                    break;
                }

                var arrayIndex = int.Parse(commandParts[1]);
                var arrayElement = int.Parse(commandParts[2]);
                var value = int.Parse(commandParts[3]);
                if (arrayIndex <0 || arrayIndex >=arrays.Length || arrayElement <0 || arrayElement >=arrays[arrayIndex].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                 if (commandName=="Add")
                {
                    arrays[arrayIndex][arrayElement]+=value;
                }
                else if (commandName=="Subtract")
                {
                    arrays[arrayIndex][arrayElement] -= value;
                }
            }
            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    Console.Write(arrays[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

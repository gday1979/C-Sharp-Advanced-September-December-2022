﻿using System;

namespace _01.OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                int counter = 0;
                StreamWriter writer = new StreamWriter(outputFilePath);
                string input;
                using (writer)
                {
                    while ((input = reader.ReadLine()) != null)
                    {
                        if (counter % 2 == 1)
                            writer.WriteLine(input);
                        counter++;
                    }
                }
            }
        }
    }
}

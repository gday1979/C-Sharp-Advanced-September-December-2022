using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var rooms = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] tokens = input.Split();
                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                if (rooms.ContainsKey(department) == false)
                {
                    rooms.Add(department, new List<string>());

                }
                if (rooms[department].Count < 60)
                {
                    rooms[department].Add(patient);
                }

                if (doctors.ContainsKey(doctor) == false)
                {
                    doctors.Add(doctor, new List<string>());
                    doctors[doctor].Add(patient);
                }
                else
                {
                    doctors[doctor].Add(patient);
                }

            }

            while ((input = Console.ReadLine().Trim()) != "End")
            {
                if (rooms.ContainsKey(input))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, rooms[input]));
                }
                else if (doctors.ContainsKey(input))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, doctors[input].OrderBy(x => x)));
                }
                else
                {
                    string[] tokens = input.Split();
                    string department = tokens[0];
                    int room = int.Parse(tokens[1]);
                    int startIndex = room * 3 - 1;
                    SortedSet<string> currentPatient = new SortedSet<string>();

                    for (int counter = startIndex - 2; counter <= startIndex; counter++)
                    {
                        currentPatient.Add(rooms[department][counter]);
                    }
                    Console.WriteLine(string.Join(Environment.NewLine, currentPatient));
                }


            }

        }
    }
}
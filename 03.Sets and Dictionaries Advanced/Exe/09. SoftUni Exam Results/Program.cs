using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> studentGradeList = new Dictionary<string, int>();
            Dictionary<string, int> testCountList = new Dictionary<string, int>();
            Dictionary<string, List<string>> studentTests = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "exam finished")
            {
                string[] cSplit = command.Split('-');
                if (cSplit.Length == 2)
                {
                    string studentName = cSplit[0];
                    StudentRemover(studentName, studentGradeList);

                }
                else if (cSplit.Length == 3)
                {
                    string studentName = $"{cSplit[0]}-{cSplit[1]}";
                    string testName = cSplit[1];
                    int grade = int.Parse(cSplit[2]);
                    StudentTestAdd(studentName, grade, studentGradeList);
                    TestCounter(testName, testCountList);
                }

                command = Console.ReadLine();
            }

            testCountList = testCountList.OrderByDescending(x => x.Value).ThenBy(x => x.Key).
                ToDictionary(key => key.Key, value => value.Value);
            studentGradeList = studentGradeList.OrderByDescending(x => x.Value).ThenBy(x => x.Key).
                ToDictionary(key => key.Key, value => value.Value);
            StudentPrinter(studentGradeList);
            CounterPrinter(testCountList);
        }




        static void StudentPrinter(Dictionary<string, int> studentGradeList)
        {
            Console.WriteLine("Results:");

            foreach (var student in studentGradeList)
            {
                string[] name = student.Key.Split('-');
                Console.WriteLine($"{name[0]} | {student.Value}");
            }
        }

        static void CounterPrinter(Dictionary<string, int> testCountList)
        {
            Console.WriteLine("Submissions:");

            foreach (var test in testCountList)
            {
                Console.WriteLine($"{test.Key} - {test.Value}");
            }
        }

        static Dictionary<string, int> StudentRemover(string studentName, Dictionary<string, int> studentGradeList)
        {
            foreach (var student in studentGradeList)
            {
                string[] currentName = student.Key.Split('-');

                if (currentName[0] == studentName)
                {
                    studentGradeList.Remove(student.Key);
                }
            }

            return studentGradeList;
        }

        static Dictionary<string, int> TestCounter(string testName, Dictionary<string, int> testCountList)
        {
            if (!testCountList.ContainsKey(testName))
            {
                testCountList.Add(testName, 0);
            }

            testCountList[testName]++;

            return testCountList;
        }

        static Dictionary<string, int> StudentTestAdd(string studentName, int grade, Dictionary<string, int> studentGradeList)
        {
            if (!studentGradeList.ContainsKey(studentName))
            {
                studentGradeList.Add(studentName, grade);
            }
            else
            {
                int currentGrade = studentGradeList[studentName];

                if (grade > currentGrade)
                {
                    studentGradeList[studentName] = grade;
                }
            }

            return studentGradeList;
        }
    }
}
    


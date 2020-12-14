using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> students = new Dictionary<string, double>();

            int nPairs = int.Parse(Console.ReadLine());

            for (int i = 0; i < nPairs; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(studentName))
                {
                    double average = (studentGrade + students[studentName]) / 2;

                    students[studentName] = average;
                }
                else
                {
                    students.Add(studentName, studentGrade);
                }
            }

            students = students.Where(x => x.Value >= 4.50)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}

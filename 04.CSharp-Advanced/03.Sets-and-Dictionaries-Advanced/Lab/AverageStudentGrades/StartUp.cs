using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string student = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!grades.ContainsKey(student))
                {
                    grades.Add(student, new List<decimal>());
                }

                grades[student].Add(grade);
            }

            foreach (var student in grades)
            {
                Console.Write(student.Key + " -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}

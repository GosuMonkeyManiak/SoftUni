using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>(numberOfStudents);

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] inPut = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Student newStudent = new Student(inPut[0], inPut[1], double.Parse(inPut[2]));

                students.Add(newStudent);
            }

            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < students.Count - 1; j++)
                {
                    if (students[j].Grade < students[j + 1].Grade)
                    {
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }

            foreach (var item in students)
            {
                Console.WriteLine($"{item.FirstName} {item.SecondName}: {item.Grade:f2}");
            }
        }
    }
}

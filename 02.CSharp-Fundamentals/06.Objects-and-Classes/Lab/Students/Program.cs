using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> allStudents = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                List<string> currentStudent = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                Student student = new Student();
                student.FirstName = currentStudent[0];
                student.LastName = currentStudent[1];
                student.Age = byte.Parse(currentStudent[2]);
                student.HomeTown = currentStudent[3];

                allStudents.Add(student);
            }

            string nameOfCity = Console.ReadLine();

            for (int i = 0; i < allStudents.Count; i++)
            {
                if (allStudents[i].HomeTown == nameOfCity)
                {
                    Console.WriteLine($"{allStudents[i].FirstName} {allStudents[i].LastName} is {allStudents[i].Age} years old.");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsTwoPointZero
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> allStudents = new List<Student>();
            bool isExist = false;

            while (true)
            {
                string info = Console.ReadLine();
                if (info == "end")
                {
                    break;
                }
                string[] splitInfo = info
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < allStudents.Count; i++)
                {
                    if (allStudents[i].FirstName == splitInfo[0] && allStudents[i].LastName == splitInfo[1] && allStudents[i].HomeTown == splitInfo[3])
                    {
                        allStudents[i].Age = byte.Parse(splitInfo[2]);
                        isExist = true;
                    }
                }

                if (isExist)
                {
                    isExist = false;
                    continue;
                }

                Student currentStudent = new Student();

                currentStudent.FirstName = splitInfo[0];
                currentStudent.LastName = splitInfo[1];
                currentStudent.Age = byte.Parse(splitInfo[2]);
                currentStudent.HomeTown = splitInfo[3];

                allStudents.Add(currentStudent);

            }

            string outPutTown = Console.ReadLine();

            foreach (var item in allStudents)
            {
                if (item.HomeTown == outPutTown)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }
        }
    }
}

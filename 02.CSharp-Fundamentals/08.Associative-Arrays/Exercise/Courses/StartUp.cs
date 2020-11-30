using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] info = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                if (info[0] == "end")
                {
                    break;
                }

                string courseName = info[0];
                string studentName = info[1];

                if (courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);
                }
            }

            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}

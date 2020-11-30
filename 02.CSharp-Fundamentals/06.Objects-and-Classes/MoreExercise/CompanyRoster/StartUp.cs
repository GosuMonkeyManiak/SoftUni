using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>(n);

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Employee newEmployee = new Employee(info[0], double.Parse(info[1]), info[2]);

                employees.Add(newEmployee);
            }

            var temp = employees.GroupBy(x => x.Department);

            double max = 0;
            string key = "";

            foreach (var item in temp)
            {
                double currentSum = employees.Where(x => x.Department == item.Key).Average(x => x.Salary);

                if (currentSum > max)
                {
                    max = currentSum;
                    key = item.Key;
                }
            }

            Console.WriteLine($"Highest Average Salary: {key}");
            foreach (var item in employees.Where(x => x.Department == key).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{item.Name} {item.Salary:f2}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                string result = GetEmployee147(context);
                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var allEmployees = context.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.Id);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in allEmployees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var filteredEmployees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in filteredEmployees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeesFromResearchAndDevelopment = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesFromResearchAndDevelopment)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employeeToChange = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employeeToChange.Address = address;

            context.SaveChanges();

            var employeesWithAddressText = context.Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesWithAddressText)
            {
                sb.AppendLine(employee);
            }

            return sb.ToString().Trim();
        }

        public static void Restore(SoftUniContext context)
        {
            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.AddressId = 291;

            var addressToDelete = context.Addresses
                .Where(a => a.AddressText == "Vitoshka 15");

            context.RemoveRange(addressToDelete.ToList());

            context.SaveChanges();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e =>
                    e.EmployeesProjects.Any(
                        ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate
                        })
                })
                .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FullName} - Manager: {employee.ManagerName}");

                foreach (var project in employee.Projects)
                {
                    sb.Append($"--{project.ProjectName} - {project.StartDate} - ");

                    if (project.EndDate == null)
                    {
                        sb.AppendLine("not finished");
                    }
                    else
                    {
                        sb.AppendLine($"{project.EndDate:M/d/yyyy h:mm:ss tt}");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addressByTown = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(e => e.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addressByTown)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employeeWithProjects = context.Employees
                .Include(ep => ep.EmployeesProjects)
                .FirstOrDefault(e => e.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                $"{employeeWithProjects.FirstName} {employeeWithProjects.LastName} - {employeeWithProjects.JobTitle}");

            foreach (var projectName in employeeWithProjects.EmployeesProjects
                .Join(context.Projects,
                    ep => ep.ProjectId,
                    p => p.ProjectId,
                    (ep, p) => new
                    {
                        p.Name
                    }
                    )
                .OrderBy(p => p.Name))
            {
                sb.AppendLine($"{projectName.Name}");
            }


            return sb.ToString().Trim();
        }
    }
}
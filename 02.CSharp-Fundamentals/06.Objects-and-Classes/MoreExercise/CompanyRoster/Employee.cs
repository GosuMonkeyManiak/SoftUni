using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    class Employee
    {
        private string name;
        private double salary;
        private string department;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }
        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public Employee(string name, double salary, string department)
        {
            this.name = name;
            this.salary = salary;
            this.department = department;
        }
    }
}

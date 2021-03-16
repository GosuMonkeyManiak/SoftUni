using System;
using System.Collections.Generic;

namespace DetailPrinter
{
    public class DetailPrinter
    {
        private IList<Employee> employees;

        public DetailPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in this.employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
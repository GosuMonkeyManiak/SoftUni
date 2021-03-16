using System;
using System.Collections.Generic;

namespace DetailPrinter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("Pesho", new List<string>()
            {
                "Pr",
                "Ner",
                "007"
            });

            Employee employee = new Employee("Gosho");

            DetailPrinter detailsPrinter = new DetailPrinter(new List<Employee>()
            {
                manager,
                employee
            });

            detailsPrinter.PrintDetails();
        }
    }
}

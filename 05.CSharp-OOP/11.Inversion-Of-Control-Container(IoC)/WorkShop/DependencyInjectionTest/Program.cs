using System;
using DependencyInjectionTest.Contracts;
using DependencyInjectionTest.Models;
using SoftUniDI;

namespace DependencyInjectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var injector = DependencyInjector.CreateInjector(new Module());

            IPrinter printer = injector.Inject<Printer>();

            printer.Print();
        }
    }
}

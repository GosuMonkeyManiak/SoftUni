using System;
using DependencyInjectionTest.Contracts;
using SoftUniDI.Attributes;

namespace DependencyInjectionTest.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
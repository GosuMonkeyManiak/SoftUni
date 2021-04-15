﻿using System;
using DependencyInjectionTest.Contracts;
using SoftUniDI.Attributes;

namespace DependencyInjectionTest.Models
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
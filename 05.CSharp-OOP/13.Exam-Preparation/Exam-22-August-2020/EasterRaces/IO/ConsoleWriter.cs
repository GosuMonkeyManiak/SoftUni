using System;
using EasterRaces.IO.Contracts;

namespace EasterRaces.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
    
}
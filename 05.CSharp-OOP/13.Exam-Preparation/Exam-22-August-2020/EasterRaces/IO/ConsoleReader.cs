using System;
using EasterRaces.IO.Contracts;

namespace EasterRaces.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
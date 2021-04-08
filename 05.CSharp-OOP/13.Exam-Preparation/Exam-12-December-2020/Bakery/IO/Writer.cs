using System;
using Bakery.IO.Contracts;

namespace Bakery.IO
{
    public class Writer : IWriter
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
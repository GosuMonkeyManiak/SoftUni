using System;
using Bakery.IO.Contracts;

namespace Bakery.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
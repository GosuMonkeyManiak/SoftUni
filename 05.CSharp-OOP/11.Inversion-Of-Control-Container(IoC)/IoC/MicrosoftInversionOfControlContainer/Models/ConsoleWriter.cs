using System;
using MicrosoftInversionOfControlContainer.Contracts;

namespace MicrosoftInversionOfControlContainer.Models
{
    public class ConsoleWriter : IWriter
    {
        private IKeyBoard _keyBoard;
        
        public ConsoleWriter(IKeyBoard keyBoard)
        {
            _keyBoard = keyBoard;
        }

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
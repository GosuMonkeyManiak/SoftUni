using System;
using MicrosoftInversionOfControlContainer.Contracts;

namespace MicrosoftInversionOfControlContainer.Models
{
    public class ConsoleReader : IReader
    {
        private ICodeTable _codeTable;
        public ConsoleReader(ICodeTable codeTable)
        {
            _codeTable = codeTable;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
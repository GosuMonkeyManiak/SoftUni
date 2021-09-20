using MicrosoftInversionOfControlContainer.Contracts;

namespace MicrosoftInversionOfControlContainer.Models
{
    public class Printer : IPrinter
    {
        private IReader _reader;
        private IWriter _writer;
        
        public Printer(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Print()
        {
            string line = _reader.ReadLine();
            _writer.WriteLine(line);
        }
    }
}
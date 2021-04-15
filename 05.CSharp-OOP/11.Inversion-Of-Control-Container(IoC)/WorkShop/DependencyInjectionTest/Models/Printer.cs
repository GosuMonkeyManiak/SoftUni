using DependencyInjectionTest.Contracts;
using SoftUniDI.Attributes;

namespace DependencyInjectionTest.Models
{
    public class Printer : IPrinter
    {
        private IReader _reader;
        private IWriter _writer;

        [Inject]
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
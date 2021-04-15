using DependencyInjectionTest.Contracts;
using DependencyInjectionTest.Models;
using SoftUniDI.Modules;

namespace DependencyInjectionTest
{
    public class Module : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IPrinter, Printer>();
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
        }
    }
}
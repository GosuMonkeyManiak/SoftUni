using System;
using MicrosoftInversionOfControlContainer.Contracts;
using MicrosoftInversionOfControlContainer.Models;

namespace CustomIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomServiceCollection serviceCollection = new CustomServiceCollection();
            serviceCollection.Map<IReader, ConsoleReader>();
            serviceCollection.Map<IWriter, ConsoleWriter>();
            serviceCollection.Map<IPrinter, Printer>();
            serviceCollection.Map<IKeyBoard, KeyBoard>();
            serviceCollection.Map<ICable, Cable>();
            serviceCollection.Map<ICodeTable, CodeTable>();

            ICustomServiceProvider serviceProvider = serviceCollection.BuildCustomServiceProvider();

            IPrinter printer = serviceProvider.GetService<IPrinter>();

            printer.Print();
        }
    }
}

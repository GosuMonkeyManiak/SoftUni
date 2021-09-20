using System;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftInversionOfControlContainer.Contracts;
using MicrosoftInversionOfControlContainer.Models;

namespace MicrosoftInversionOfControlContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IPrinter, Printer>();
            serviceCollection.AddTransient<IWriter, ConsoleWriter>();
            serviceCollection.AddTransient<IReader, ConsoleReader>();
            serviceCollection.AddTransient<IKeyBoard, KeyBoard>();
            serviceCollection.AddTransient<ICodeTable, CodeTable>();
            serviceCollection.AddTransient<ICable, Cable>();

            IServiceProvider provider = serviceCollection.BuildServiceProvider();

            IPrinter printer = provider.GetService<IPrinter>();
        }
    }
}

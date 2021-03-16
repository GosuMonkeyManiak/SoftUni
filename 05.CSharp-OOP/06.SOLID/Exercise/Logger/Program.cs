using System;
using Logger.AllReportLevels;
using Logger.Appenders;
using Logger.Contracts;
using Logger.Layouts;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandInterpreter commands = new CommandInterpreter();

            ILogger logger = commands.ReadAppenders();

            commands.LogMessage(logger);

            commands.PrintInfoForEachLogger(logger);
        }
    }
}

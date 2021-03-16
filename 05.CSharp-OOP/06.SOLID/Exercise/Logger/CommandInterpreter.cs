using System;
using System.Reflection;
using Logger.AllReportLevels;
using Logger.Appenders;
using Logger.Contracts;
using Logger.Layouts;

namespace Logger
{
    public class CommandInterpreter
    {
        public ILogger ReadAppenders()
        {
            ILogger logger = new Logger();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IAppender currentAppender = null;
                ILayout currentLayout = null;

                if (parts[1] == nameof(SimpleLayout))
                {
                    currentLayout = new SimpleLayout();
                }
                else if (parts[1] == nameof(XmlLayout))
                {
                    currentLayout = new XmlLayout();
                }
                else if (parts[1] == nameof(HtmlLayout))
                {
                    currentLayout = new HtmlLayout();
                }

                if (parts[0] == nameof(ConsoleAppender))
                {
                    currentAppender = new ConsoleAppender(currentLayout);
                }
                else if (parts[0] == nameof(FileAppender))
                {
                    currentAppender = new FileAppender(currentLayout, new LogFile());
                }

                if (parts.Length > 2)
                {
                    currentAppender.ReportLevel = Enum.Parse<Report>(parts[2], true);
                }

                logger.AddAppender(currentAppender);
            }

            return logger;
        }

        public void LogMessage(ILogger logger)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                string[] part = line
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                switch (part[0].ToLower())
                {
                    case "info":
                        logger.Info(part[1], part[2]);
                        break;

                    case "warning":
                        logger.Warning(part[1], part[2]);
                        break;

                    case "error":
                        logger.Error(part[1], part[2]);
                        break;

                    case "critical":
                        logger.Critical(part[1], part[2]);
                        break;

                    case "fatal":
                        logger.Fatal(part[1], part[2]);
                        break;
                }
            }
        }

        public void PrintInfoForEachLogger(ILogger logger)
        {
            Console.WriteLine("Logger info");

            foreach (var appender in logger.Appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }

    }
}
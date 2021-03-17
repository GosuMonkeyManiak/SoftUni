using System;
using System.Linq;
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

                var appendersType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsAssignableTo(typeof(IAppender)) && x.Name != nameof(IAppender))
                    .ToList();

                var layoutTypes = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsAssignableTo(typeof(ILayout)) && x.Name != nameof(ILayout))
                    .ToList();

                var appenderType = appendersType
                    .FirstOrDefault(x => x.Name == parts[0]);

                var layoutType = layoutTypes
                    .FirstOrDefault(x => x.Name == parts[1]);

                currentLayout = (ILayout)Activator.CreateInstance(layoutType);
                currentAppender = (IAppender)Activator.CreateInstance(appenderType, new object[] { currentLayout });


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
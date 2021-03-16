using System.Collections.Generic;
using Logger.AllReportLevels;
using Logger.Contracts;

namespace Logger
{
    public class Logger : ILogger
    {
        private List<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>(appenders);
        }

        public IReadOnlyList<IAppender> Appenders => this.appenders.AsReadOnly();

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        public void Info(string date, string msg)
        {
            foreach (var appender in appenders)
            {
                appender.AppendMessage(date, Report.Info.ToString(), msg);
            }
        }

        public void Warning(string date, string msg)
        {
            foreach (var appender in appenders)
            {
                appender.AppendMessage(date, Report.Warning.ToString(), msg);
            }
        }

        public void Error(string date, string msg)
        {
            foreach (var appender in appenders)
            {
                appender.AppendMessage(date, Report.Error.ToString(), msg);
            }
        }

        public void Critical(string date, string msg)
        {
            foreach (var appender in appenders)
            {
                appender.AppendMessage(date, Report.Critical.ToString(), msg);
            }
        }

        public void Fatal(string date, string msg)
        {
            foreach (var appender in appenders)
            {
                appender.AppendMessage(date, Report.Fatal.ToString(), msg);
            }
        }
    }
}
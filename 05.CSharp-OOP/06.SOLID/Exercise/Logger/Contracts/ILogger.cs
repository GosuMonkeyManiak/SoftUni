using System.Collections.Generic;

namespace Logger.Contracts
{
    public interface ILogger
    {
        public IReadOnlyList<IAppender> Appenders { get;  }

        public void AddAppender(IAppender appender);

        public void Error(string date, string msg);

        public void Info(string date, string msg);

        public void Warning(string date, string msg);

        public void Critical(string date, string msg);

        public void Fatal(string date, string msg);

    }
}
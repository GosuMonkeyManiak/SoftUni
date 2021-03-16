using System;
using System.Text;
using Logger.AllReportLevels;
using Logger.Contracts;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;
        private int countMessage;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }
        
        public Report ReportLevel { get; set; }

        public void AppendMessage(string date, string reportLevel, string msg)
        {
            Report currentReport = Enum.Parse<Report>(reportLevel, true);

            if (currentReport >= ReportLevel)
            {
                Console.WriteLine(layout.CreateMessage(date, reportLevel, msg));
                this.countMessage++;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Appender type: {this.GetType().Name}, {layout} Report level: {ReportLevel}, Messages appended: {countMessage}");

            return sb.ToString().Trim();
        }
    }
}
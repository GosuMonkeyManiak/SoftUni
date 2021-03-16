using System;
using System.IO;
using System.Text;
using Logger.AllReportLevels;
using Logger.Contracts;

namespace Logger.Appenders
{
    public class FileAppender : IAppender
    {
        private ILayout layout;
        private ILogableFileInfo file;
        private int countMessage;

        public FileAppender(ILayout layout, ILogableFileInfo file)
        {
            this.layout = layout;
            this.file = file;
        }

        public Report ReportLevel { get; set; }

        public void AppendMessage(string date, string reportLevel, string msg)
        {
            Report currentReport = Enum.Parse<Report>(reportLevel, true);

            if (currentReport >= ReportLevel)
            {
                string currentMsg = layout.CreateMessage(date, ReportLevel.ToString(), msg);

                using (StreamWriter writer = new StreamWriter("../../../log.txt", true))
                {
                    writer.WriteLine(currentMsg);
                }

                file.Write(currentMsg);
                countMessage++;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Appender type: {this.GetType().Name}, {layout} Report level: {ReportLevel}, Messages appended: {countMessage}, File size: {file.Size}");

            return sb.ToString().Trim();
        }
    }
}
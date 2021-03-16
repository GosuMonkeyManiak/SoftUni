using Logger.AllReportLevels;

namespace Logger.Contracts
{
    public interface IAppender
    {
        public Report ReportLevel { get; set; }

        void AppendMessage(string date, string reportLevel, string msg);
    }
}
using Logger.Contracts;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        //<date-time> - <report level> - <message>  

        public SimpleLayout()
        {
            
        }

        public string CreateMessage(string date, string reportLevel, string msg)
        {
            return $"{date} - {reportLevel} - {msg}";
        }

        public override string ToString()
        {
            return $"Layout type: {this.GetType().Name},".Trim();
        }
    }
}
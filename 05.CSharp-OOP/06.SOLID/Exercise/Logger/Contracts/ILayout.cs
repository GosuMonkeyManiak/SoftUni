using System.Collections.Generic;

namespace Logger.Contracts
{
    public interface ILayout
    {
        string CreateMessage(string date, string reportLevel, string msg);
    }
}
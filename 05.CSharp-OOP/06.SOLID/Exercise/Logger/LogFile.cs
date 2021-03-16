using Logger.Contracts;
using System.Linq;
using System.Text;

namespace Logger
{
    public class LogFile : ILogableFileInfo
    {
        private StringBuilder sb;

        public LogFile()
        {
            sb = new StringBuilder();
        }

        public int Size => CalcualteSize(sb.ToString());

        public void Write(string msg)
        {
            sb.Append(msg);
        }

        private int CalcualteSize(string msg)
        {
            int size = msg.Where(x => char.IsLetter(x)).Sum(x => x);

            return size;
        }
    }
}

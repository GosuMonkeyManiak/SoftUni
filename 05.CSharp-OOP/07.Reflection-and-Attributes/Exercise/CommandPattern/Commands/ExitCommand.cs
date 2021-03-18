using CommandPattern.Core.Contracts;

namespace CommandPattern.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
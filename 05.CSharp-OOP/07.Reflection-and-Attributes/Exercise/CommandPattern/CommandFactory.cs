using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandType)
        {
            var type = Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(ICommand)))
                .FirstOrDefault(x => x.Name.StartsWith(commandType));

            return (ICommand)Activator.CreateInstance(type);
        }
    }
}
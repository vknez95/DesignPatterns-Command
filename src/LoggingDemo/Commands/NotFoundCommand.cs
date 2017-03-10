using System;

namespace LoggingDemo.Commands
{
    public class NotFoundCommand : ICommand, ICommandFactory
    {
        private readonly string _name;

        public NotFoundCommand(string commandName)
        {
            _name = commandName;
        }

        public string CommandName { get { return "NotFound"; } }
        public string Description { get { return "Do not display this command"; } }

        public void Execute()
        {
            Console.WriteLine("Couldn't find command: " + _name);
        }

        public ICommand MakeCommand(string[] arguments)
        {
            return this;
        }
    }
}
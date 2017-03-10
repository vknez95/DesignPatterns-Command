using System;
using System.Collections.Generic;
using System.Linq;
using LoggingDemo.Commands;
using LoggingDemo.Util;

namespace LoggingDemo
{
    public class CommandParser
    {
        readonly IEnumerable<ICommandFactory> availableCommands;

        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            this.availableCommands = availableCommands;
        }

        internal ICommand ParseCommand(string[] args)
        {
            var requestedCommandName = args[0];

            var command = FindRequestedCommand(requestedCommandName);

            return command.MakeCommand(args);
        }

        ICommandFactory FindRequestedCommand(string commandName)
        {
            return availableCommands
                .Where(cmd => cmd.CommandName == commandName)
                .DefaultIfEmpty(() => new NotFoundCommand(commandName))
                .Single();
        }
    }
}
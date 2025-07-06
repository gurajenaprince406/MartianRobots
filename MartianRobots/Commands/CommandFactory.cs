using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Commands
{
    public static class CommandFactory
    {
        public static ICommand CreateCommand(char commandChar)
        {
            return commandChar switch
            {
                'L' => new TurnLeftCommand(),
                'R' => new TurnRightCommand(),
                'F' => new MoveForwardCommand(),
                _ => throw new ArgumentException($"Invalid command: {commandChar}")
            };
        }

        public static IEnumerable<ICommand> CreateCommands(string commandString)
        {
            return commandString.Select(CreateCommand);
        }
    }
}

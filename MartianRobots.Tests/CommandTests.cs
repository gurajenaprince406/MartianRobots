using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Tests
{
    public class CommandTests
    {
        [Fact]
        public void CommandFactory_CreatesCorrectCommands()
        {
            var commands = CommandFactory.CreateCommands("LFR");

            Assert.IsType<TurnLeftCommand>(commands.ElementAt(0));
            Assert.IsType<MoveForwardCommand>(commands.ElementAt(1));
            Assert.IsType<TurnRightCommand>(commands.ElementAt(2));
        }
    }
}

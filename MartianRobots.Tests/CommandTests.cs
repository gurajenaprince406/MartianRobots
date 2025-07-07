using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using MartianRobots.Commands;

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

using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using MartianRobots.Models;
using Xunit;


namespace MartianRobots.Tests
{
    public class RobotTests
    {
        [Fact]
        public void Robot_TurnsLeft_Correctly()
        {
            var grid = new Grid(5, 5);
            var robot = new Robot(1, 1, Orientation.N, grid);

            robot.TurnLeft();
            Assert.Equal(Orientation.W, robot.Orientation);

            robot.TurnLeft();
            Assert.Equal(Orientation.S, robot.Orientation);
        }

        [Fact]
        public void Robot_TurnsRight_Correctly()
        {
            var grid = new Grid(5, 5);
            var robot = new Robot(1, 1, Orientation.N, grid);

            robot.TurnRight();
            Assert.Equal(Orientation.E, robot.Orientation);

            robot.TurnRight();
            Assert.Equal(Orientation.S, robot.Orientation);
        }

        [Fact]
        public void Robot_MovesForward_Correctly()
        {
            var grid = new Grid(5, 5);
            var robot = new Robot(1, 1, Orientation.N, grid);

            robot.MoveForward();
            Assert.Equal(1, robot.X);
            Assert.Equal(2, robot.Y);
        }

        [Fact]
        public void Robot_FallsOffGrid_AndLeavesScent()
        {
            var grid = new Grid(5, 5);
            var robot = new Robot(5, 5, Orientation.N, grid);

            robot.MoveForward();
            Assert.True(robot.IsLost);
            Assert.True(grid.HasScentMarker(5, 5));
        }

        [Fact]
        public void Robot_IgnoresMove_WhenScentPresent()
        {
            var grid = new Grid(5, 5);
            grid.AddScentMarker(5, 5);

            var robot = new Robot(5, 5, Orientation.N, grid);
            robot.MoveForward();

            Assert.False(robot.IsLost);
            Assert.Equal(5, robot.X);
            Assert.Equal(5, robot.Y);
        }
    }
}
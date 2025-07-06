using MartianRobots.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.IO
{
    public static class InputParser
    {
        public static Grid ParseGrid(string line)
        {
            var parts = line.Split(' ');
            if (parts.Length != 2 || !int.TryParse(parts[0], out var x) || !int.TryParse(parts[1], out var y))
                throw new ArgumentException("Invalid grid dimensions");

            return new Grid(x, y);
        }

        public static (int x, int y, Orientation orientation) ParseRobotPosition(string line)
        {
            var parts = line.Split(' ');
            if (parts.Length != 3 || !int.TryParse(parts[0], out var x) || !int.TryParse(parts[1], out var y))
                throw new ArgumentException("Invalid robot position");

            if (!Enum.TryParse(parts[2], out Orientation orientation))
                throw new ArgumentException("Invalid orientation");

            return (x, y, orientation);
        }

        public static string ParseRobotCommands(string line) => line.Trim();
    }
}

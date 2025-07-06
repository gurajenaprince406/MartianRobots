using MartianRobots.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.IO
{
    public static class OutputGenerator
    {
        public static string GenerateOutput(Robot robot)
        {
            return robot.IsLost
                ? $"{robot.X} {robot.Y} {robot.Orientation} LOST"
                : $"{robot.X} {robot.Y} {robot.Orientation}";
        }
    }
}

using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void SampleInput_ProducesCorrectOutput()
        {
            var inputLines = new List<string>
        {
            "5 3",
            "1 1 E",
            "RFRFRFRF",
            "3 2 N",
            "FRRFLLFFRRFLL",
            "0 3 W",
            "LLFFFLFLFL"
        };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            Program.ProcessInput(inputLines);

            var output = sw.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal("1 1 E", output[0]);
            Assert.Equal("3 3 N LOST", output[1]);
            Assert.Equal("2 3 S", output[2]);
        }
    }
}

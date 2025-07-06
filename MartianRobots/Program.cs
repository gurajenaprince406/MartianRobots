using MartianRobots.Commands;
using MartianRobots.IO;
using MartianRobots.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var inputLines = new List<string>();
        string line;

        while ((line = Console.ReadLine()) != null)
        {
            inputLines.Add(line);
        }

        ProcessInput(inputLines);
    }

    public static void ProcessInput(List<string> inputLines)
    {
        if (inputLines.Count < 3 || (inputLines.Count - 1) % 2 != 0)
        {
            Console.WriteLine("Invalid input format");
            return;
        }

        var grid = InputParser.ParseGrid(inputLines[0]);

        for (int i = 1; i < inputLines.Count; i += 2)
        {
            if (i + 1 >= inputLines.Count) break;

            var (x, y, orientation) = InputParser.ParseRobotPosition(inputLines[i]);
            var commandString = InputParser.ParseRobotCommands(inputLines[i + 1]);

            var robot = new Robot(x, y, orientation, grid);
            var commands = CommandFactory.CreateCommands(commandString);

            robot.ExecuteCommands(commands);
            Console.WriteLine(OutputGenerator.GenerateOutput(robot));
        }
    }
}
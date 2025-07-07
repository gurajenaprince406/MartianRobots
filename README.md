# MartianRobots
I have created a C# application that simulates the movement of robots on Mars according to the given specifications. Here's my approach:

Solution Structure
Core Models:

Grid - Represents the Martian grid with dimensions and scent markers

Robot - Represents a robot with position, orientation, and movement logic

Orientation - Enum for cardinal directions

Command Pattern:

ICommand interface for robot instructions

Concrete command classes for Left, Right, Forward

Command factory to create commands from input

Input/Output Processing:

InputParser to read and parse input data

OutputGenerator to format the results

Unit Tests:

Tests for core movement logic

Tests for edge cases (falling off grid, scent markers)

Tests for input parsing.

How to Run
Clone the repository

Open the solution in Visual Studio or VS Code

Build the solution

Run the tests to verify functionality

Run the console application and provide input (or pipe input file).

This approach demonstrates:

Starting with core domain models

Building up functionality incrementally

Testing at each stage

Keeping the solution simple and focused

Following SOLID principles (especially with the command pattern)

The solution is extensible for new commands and maintains clean separation of concerns.
How to run the Application:

Press F5 to run

The program will wait for input - you can paste the sample input:

text
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
Press Ctrl+Z then Enter to signal end of input (or Ctrl+D on some systems)

You should see the sample output

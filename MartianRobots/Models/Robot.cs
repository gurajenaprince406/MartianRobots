using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Commands;
using System.Threading.Tasks;
//using System.Windows.Input;

namespace MartianRobots.Models
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Orientation Orientation { get; private set; }
        public bool IsLost { get; private set; }
        private readonly Grid _grid;

        public Robot(int x, int y, Orientation orientation, Grid grid)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            _grid = grid;
            IsLost = false;
        }

        public void ExecuteCommands(IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
            {
                if (IsLost) break;
                command.Execute(this);
            }
        }

        public void MoveForward()
        {
            var (newX, newY) = GetNextPosition();

            if (!_grid.IsPositionValid(newX, newY))
            {
                if (!_grid.HasScentMarker(X, Y))
                {
                    _grid.AddScentMarker(X, Y);
                    IsLost = true;
                }
                return;
            }

            X = newX;
            Y = newY;
        }

        private (int, int) GetNextPosition()
        {
            return Orientation switch
            {
                Orientation.N => (X, Y + 1),
                Orientation.E => (X + 1, Y),
                Orientation.S => (X, Y - 1),
                Orientation.W => (X - 1, Y),
                _ => (X, Y)
            };
        }

        public void TurnLeft()
        {
            Orientation = Orientation switch
            {
                Orientation.N => Orientation.W,
                Orientation.W => Orientation.S,
                Orientation.S => Orientation.E,
                Orientation.E => Orientation.N,
                _ => Orientation
            };
        }

        public void TurnRight()
        {
            Orientation = Orientation switch
            {
                Orientation.N => Orientation.E,
                Orientation.E => Orientation.S,
                Orientation.S => Orientation.W,
                Orientation.W => Orientation.N,
                _ => Orientation
            };
        }
    }
}

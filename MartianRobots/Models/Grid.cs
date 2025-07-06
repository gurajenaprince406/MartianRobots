using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Models
{
    public class Grid
    {
        public int MaxX { get; }
        public int MaxY { get; }
        private readonly HashSet<(int, int)> _scentMarkers = new();

        public Grid(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsPositionValid(int x, int y)
        {
            return x >= 0 && x <= MaxX && y >= 0 && y <= MaxY;
        }

        public void AddScentMarker(int x, int y)
        {
            _scentMarkers.Add((x, y));
        }

        public bool HasScentMarker(int x, int y)
        {
            return _scentMarkers.Contains((x, y));
        }
    }
}

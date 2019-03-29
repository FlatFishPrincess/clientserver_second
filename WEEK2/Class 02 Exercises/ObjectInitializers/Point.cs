using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    // enum for point colors. Note these are just dummy names

    public enum PointColor
    { LightBlue, BloodRed, Gold }

    /// <summary>
    /// initialize a point by color, or by location and a default color of Gold
    /// </summary>

    class Point
    {
        // X and Y coordinates of the point
        public int X { get; set; }
        public int Y { get; set; }
        public PointColor Color { get; set; }

        public Point(int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
            Color = PointColor.Gold;
        }

        public Point(PointColor ptColor)
        {
            Color = ptColor;
        }

        // default constructor sets color to BloodRed
        // X and Y need to be set manually

        public Point()
          : this(PointColor.BloodRed)
        {
        }

        /// <summary>
        /// Display coordinates and colors
        /// </summary>
        public void DisplayStats()
        {
            Console.WriteLine($"[{X}, {Y}] is {Color} color");
        }
    }
}

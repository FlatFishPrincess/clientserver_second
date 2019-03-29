using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    /// <summary>
    /// initialize a rectangle with two points, and properties to get and set
    /// notice no need for constructor here ... although it could be used.
    /// </summary>
    class Rectangle
    {

        // use of backing store for properties

        private Point topLeft = new Point();
        private Point bottomRight = new Point();

        public Point TopLeft
        {
            get { return topLeft; }
            set { topLeft = value; }
        }
        public Point BottomRight
        {
            get { return bottomRight; }
            set { bottomRight = value; }
        }

        public void DisplayStats()
        {
            Console.WriteLine("Rectangle [TopLeft: [{0}, {1}] color {2} BottomRight: [{3}, {4}] color {5}]",
              topLeft.X, topLeft.Y, topLeft.Color,
              bottomRight.X, bottomRight.Y, bottomRight.Color);
        }
    }
}

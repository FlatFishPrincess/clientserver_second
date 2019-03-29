using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    class ObjectInitializersProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Initializers *****\n");

            // Make a Point by setting each property manually.
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();
            Console.WriteLine();

            // Or make a Point via a custom constructor.
            Point anotherPoint = new Point(20, 20);
            anotherPoint.DisplayStats();
            Console.WriteLine();

            // Or make a Point using object init syntax.
            Point finalPoint = new Point
            {
                X = 30,
                Y = 30
            };
            finalPoint.DisplayStats();
            Console.WriteLine();

            // Calling a more interesting custom constructor with init syntax.
            Point goldPoint = new Point(PointColor.Gold)
            {
                X = 90,
                Y = 20
            };
            goldPoint.DisplayStats();
            Console.WriteLine();

            // Create and initialize a Rectangle.
            Rectangle myRect = new Rectangle
            {
                TopLeft = new Point { X = 15, Y = 15 },
                BottomRight = new Point { X = 200, Y = 200 }
            };
            myRect.DisplayStats();

            Console.WriteLine();

            // another way of using Rectangle
            // since Rectangle creates TopLeft and BottomRight Points, just set them.

            Rectangle anotherRectangle = new Rectangle
            {
                TopLeft = firstPoint,
                BottomRight = anotherPoint
            };
            anotherRectangle.DisplayStats();

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}

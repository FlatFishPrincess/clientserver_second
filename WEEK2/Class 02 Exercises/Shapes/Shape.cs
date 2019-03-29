using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    // The abstract base class of the hierarchy. Note that this cannot be used except as a base class!
    abstract class Shape
    {
        public Shape(string name = "NoName")
        {
            ShapeName = name;
        }

        public string ShapeName { get; set; }

        // Force all child classes to define how a shape is to be rendered.
        public abstract void Draw();
    }

    // for each class below, default constructor sets ShapeName to NoName
    //    paramaterized constructor sets ShapeName to the param, calls parent

    #region Circle class
    class Circle : Shape
    {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", ShapeName);
        }
    }
    #endregion

    #region Hexagon class 
    class Hexagon : Shape
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", ShapeName);
        }
    }
    #endregion

    #region 3D circle
    class ThreeDCircle : Circle
    {
        // Hide the ShapeName property in the base class.
        public new string ShapeName { get; set; } = "NoName3DCircle";

        // Hide any Draw() implementation above me.
        public new void Draw()
        {
            Console.WriteLine("Drawing {0} the 3D Circle", ShapeName);
        }
    }
    #endregion
}

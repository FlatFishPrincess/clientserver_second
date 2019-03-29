using System;

namespace BaseKeywordAndClasses
{
    // demonstration of base and derived (parent and child) classes and their constructors

    class BaseKeywordAndClassesProgram
    {
        static void Main(string[] args)
        {
            Child myChild = new Child();
            Parent myParent = new Parent();

            Console.WriteLine("Initial properties");

            Console.WriteLine($"Child prop {myChild.ParentProperty} Child anotherprop {myChild.AnotherParentProperty} " +
                $"Parent prop {myParent.ParentProperty} Parent anotherprop {myParent.AnotherParentProperty}");

            myChild.ParentProperty = 20;  // this will actually set it to 30, see override below

            Console.WriteLine("Child changes parent property to 20, but it ends up as 30");

            Console.WriteLine($"Child prop {myChild.ParentProperty} Child anotherprop {myChild.AnotherParentProperty} " +
                $"Parent prop {myParent.ParentProperty} Parent anotherprop {myParent.AnotherParentProperty}");
            Console.ReadLine();
        }
    }
    class Parent
    {
        public virtual int ParentProperty { get; set; } = 5;  // this is virtual as it can be overridden
        public int AnotherParentProperty { get; set; }

        public Parent() : this(100)
        {
            // anotherParentProp = 100; setting the other parent property to 100
        }

        public Parent(int n)
        {
            AnotherParentProperty = n;
        }
    }

    class Child : Parent
    {
        // override the parent's property, setting the base class (parent) property to add 10 to it

        public override int ParentProperty { set { base.ParentProperty = value + 10; } }

        public Child() : base(1000)
        {

        }
    }
}

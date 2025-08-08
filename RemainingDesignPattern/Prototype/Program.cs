using Microsoft.Win32.SafeHandles;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prototype Design Pattern: In below example we dont know the type of object");
            Shape shape = MenuSelection(); // user selected shape from menu selection
            shape.Draw();

            // user wanting to draw same shape
            Shape shape2 = shape.Clone();
            shape2.Draw();
       }

        public static Shape MenuSelection()
        {
            return new Line();
        }
    }

    abstract class Shape()
    {
        public abstract void Draw();
        public abstract Shape Clone();
    }

    class Line : Shape
    {
        public override Shape Clone()
        {
            return new Line().mem;
        }

        public override void Draw()
        {
            Console.WriteLine("line");
        }
    }

    class Rectangle : Shape
    {
        public override Shape Clone()
        {
            return new Rectangle();
        }

        public override void Draw()
        {
            Console.WriteLine("rectangle");
        }
    }
}

namespace Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("polymorphism: many objects reacting to same msg/command differently");
            IFly[] f = new IFly[] { new Superman(), new Mosquito(), new Plane() };
            foreach( IFly flyobj in f )
            {
                flyobj.Fly(); // polymorphism: many objects reacting to same msg/command differently. Fly is a msg/command in this case
            }
        }
    }

    interface IFly // Polymorphism within classes that are not related
    {
        public void Fly();
    }

    internal class Superman : IFly { 
        public void Fly()
        {
            Console.WriteLine("Superman is flying");
        }
    }

    internal class Mosquito : IFly
    {
        public void Fly()
        {
            Console.WriteLine("Mosquito is flying");
        }
    }

    internal class Plane : IFly
    {
        public void Fly()
        {
            Console.WriteLine("Plane is flying");
        }
    }

    // abstract class // polymorphism on classes that are not related
    // extending class

    //notes: To be able to achieve the polymorphism in static language, a virtual table hack was created.[]. In pure object oriented language, this is not the case. Try python.
    // when you create virtual,override then 
}

using System;

// ============================================================================
//                        FACTORY METHOD PATTERN EXAMPLE
// ============================================================================
    // Product interface
    public interface IVehicle
    {
        void Start();
        void Stop();
    }

    // Concrete products
    public class Car : IVehicle
    {
        public void Start() => Console.WriteLine("🚗 Car engine started");
        public void Stop() => Console.WriteLine("🚗 Car engine stopped");
    }

    public class Motorcycle : IVehicle
    {
        public void Start() => Console.WriteLine("🏍️ Motorcycle engine started");
        public void Stop() => Console.WriteLine("🏍️ Motorcycle engine stopped");
    }

    // Creator (Factory Method)
    public abstract class VehicleFactory
    {
        // Factory method - subclasses decide which vehicle to create
        public abstract IVehicle CreateVehicle();

        // Template method that uses the factory method
        public void TestVehicle()
        {
            var vehicle = CreateVehicle();  // ← Single factory method
            vehicle.Start();
            vehicle.Stop();
        }
    }

    // Concrete creators
    public class CarFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle() => new Car();
    }

    public class MotorcycleFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle() => new Motorcycle();
    }

// ============================================================================
//                       ABSTRACT FACTORY PATTERN EXAMPLE
// ============================================================================
    // Abstract products - Multiple product types
    public interface IButton
    {
        void Click();
    }

    public interface ICheckbox
    {
        void Toggle();
    }

    public interface IMenu
    {
        void Open();
    }

    // Windows family products
    public class WindowsButton : IButton
    {
        public void Click() => Console.WriteLine("🖱️ Windows button clicked");
    }

    public class WindowsCheckbox : ICheckbox
    {
        public void Toggle() => Console.WriteLine("☑️ Windows checkbox toggled");
    }

    public class WindowsMenu : IMenu
    {
        public void Open() => Console.WriteLine("📋 Windows menu opened");
    }

    // Mac family products
    public class MacButton : IButton
    {
        public void Click() => Console.WriteLine("🖱️ Mac button clicked");
    }

    public class MacCheckbox : ICheckbox
    {
        public void Toggle() => Console.WriteLine("☑️ Mac checkbox toggled");
    }

    public class MacMenu : IMenu
    {
        public void Open() => Console.WriteLine("📋 Mac menu opened");
    }

    // Abstract factory - Multiple factory methods for related products
    public abstract class GUIFactory
    {
        public abstract IButton CreateButton();      // ← Multiple factory methods
        public abstract ICheckbox CreateCheckbox();  // ← for creating families
        public abstract IMenu CreateMenu();          // ← of related objects
    }

    // Concrete factories - Create entire families
    public class WindowsFactory : GUIFactory
    {
        public override IButton CreateButton() => new WindowsButton();
        public override ICheckbox CreateCheckbox() => new WindowsCheckbox();
        public override IMenu CreateMenu() => new WindowsMenu();
    }

    public class MacFactory : GUIFactory
    {
        public override IButton CreateButton() => new MacButton();
        public override ICheckbox CreateCheckbox() => new MacCheckbox();
        public override IMenu CreateMenu() => new MacMenu();
    }

    // Client code - Uses entire families
    public class Application
    {
        private readonly GUIFactory _factory;

        public Application(GUIFactory factory)
        {
            _factory = factory;
        }

        public void CreateUI()
        {
            // Creates a complete family of compatible UI elements
            var button = _factory.CreateButton();
            var checkbox = _factory.CreateCheckbox();
            var menu = _factory.CreateMenu();

            button.Click();
            checkbox.Toggle();
            menu.Open();
        }
    }

// ============================================================================
//                              DEMONSTRATION
// ============================================================================

class PatternComparison
{
    public static void Main()
    {
        Console.WriteLine("🔧 FACTORY METHOD PATTERN:");
        Console.WriteLine("Creates ONE object at a time\n");

        // Factory Method - Creates single objects
        var carFactory = new CarFactory();
        var motorcycleFactory = new MotorcycleFactory();

        Console.WriteLine("Car Factory:");
        carFactory.TestVehicle();

        Console.WriteLine("\nMotorcycle Factory:");
        motorcycleFactory.TestVehicle();

        Console.WriteLine("\n" + new string('=', 60));

        Console.WriteLine("\n🏗️ ABSTRACT FACTORY PATTERN:");
        Console.WriteLine("Creates FAMILIES of related objects\n");

        // Abstract Factory - Creates families of related objects
        var windowsFactory = new WindowsFactory();
        var macFactory = new MacFactory();

        Console.WriteLine("Windows Application:");
        var windowsApp = new Application(windowsFactory);
        windowsApp.CreateUI();

        Console.WriteLine("\nMac Application:");
        var macApp = new Application(macFactory);
        macApp.CreateUI();

        Console.WriteLine("\n" + new string('=', 60));

        Console.WriteLine("\n📊 KEY DIFFERENCES DEMONSTRATED:");
        Console.WriteLine("• Factory Method: Each factory creates ONE type of object");
        Console.WriteLine("• Abstract Factory: Each factory creates MULTIPLE related objects");
        Console.WriteLine("• Factory Method: Uses inheritance (subclassing)");
        Console.WriteLine("• Abstract Factory: Uses composition (object delegation)");
        Console.WriteLine("• Factory Method: Products are independent");
        Console.WriteLine("• Abstract Factory: Products work together as a family");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

using System;
using System.Collections.Generic;

// Abstract Products - Define interfaces for product families
public abstract class Computer
{
    protected string description = "";
    
    public abstract void AssembleComponents(int cpu, int ram, int storage, int display);
    
    public string GetInfo() => description;
}

public abstract class Monitor
{
    protected string description = "";
    
    public abstract void SetupDisplay(int size, string resolution);
    
    public string GetInfo() => description;
}

// Concrete Products - Dell Family
public class DellDesktop : Computer
{
    public override void AssembleComponents(int cpu, int ram, int storage, int display)
    {
        description = $"DELL Desktop PC: CPU {cpu} cores, RAM {ram}GB, Storage {storage}GB, Display Port {display}";
    }
}

public class DellLaptop : Computer
{
    public override void AssembleComponents(int cpu, int ram, int storage, int display)
    {
        description = $"DELL Laptop: CPU {cpu} cores, RAM {ram}GB, Storage {storage}GB, Built-in Display {display}\"";
    }
}

public class DellMonitor : Monitor
{
    public override void SetupDisplay(int size, string resolution)
    {
        description = $"DELL Monitor: {size}\" {resolution} Professional Display";
    }
}

// Concrete Products - Apple Family
public class AppleiMac : Computer
{
    public override void AssembleComponents(int cpu, int ram, int storage, int display)
    {
        description = $"APPLE iMac: M-Series CPU {cpu} cores, RAM {ram}GB, SSD {storage}GB, Retina Display {display}\"";
    }
}

public class AppleMacBook : Computer
{
    public override void AssembleComponents(int cpu, int ram, int storage, int display)
    {
        description = $"APPLE MacBook: M-Series CPU {cpu} cores, RAM {ram}GB, SSD {storage}GB, Retina Display {display}\"";
    }
}

public class AppleStudioDisplay : Monitor
{
    public override void SetupDisplay(int size, string resolution)
    {
        description = $"APPLE Studio Display: {size}\" {resolution} 5K Retina Display";
    }
}

// Abstract Factory - Defines interface for creating families of products
public abstract class ComputerFactory
{
    public abstract Computer CreateDesktop();
    public abstract Computer CreateLaptop();
    public abstract Monitor CreateMonitor();
}

// Concrete Factories - Create families of related products
public class DellFactory : ComputerFactory
{
    public override Computer CreateDesktop()
    {
        return new DellDesktop();
    }

    public override Computer CreateLaptop()
    {
        return new DellLaptop();
    }

    public override Monitor CreateMonitor()
    {
        return new DellMonitor();
    }
}

public class AppleFactory : ComputerFactory
{
    public override Computer CreateDesktop()
    {
        return new AppleiMac();
    }

    public override Computer CreateLaptop()
    {
        return new AppleMacBook();
    }

    public override Monitor CreateMonitor()
    {
        return new AppleStudioDisplay();
    }
}

// Client Code - Uses abstract factory
public class ComputerStore
{
    private readonly ComputerFactory _factory;
    private readonly List<Computer> _computers = new();
    private readonly List<Monitor> _monitors = new();

    public ComputerStore(ComputerFactory factory)
    {
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    public Computer OrderDesktop(int cpu, int ram, int storage, int display)
    {
        var computer = _factory.CreateDesktop();
        computer.AssembleComponents(cpu, ram, storage, display);
        _computers.Add(computer);
        return computer;
    }

    public Computer OrderLaptop(int cpu, int ram, int storage, int display)
    {
        var computer = _factory.CreateLaptop();
        computer.AssembleComponents(cpu, ram, storage, display);
        _computers.Add(computer);
        return computer;
    }

    public Monitor OrderMonitor(int size, string resolution)
    {
        var monitor = _factory.CreateMonitor();
        monitor.SetupDisplay(size, resolution);
        _monitors.Add(monitor);
        return monitor;
    }

    public void ListInventory()
    {
        Console.WriteLine("\n=== COMPUTERS ===");
        _computers.ForEach(computer => Console.WriteLine($"- {computer.GetInfo()}"));
        
        Console.WriteLine("\n=== MONITORS ===");
        _monitors.ForEach(monitor => Console.WriteLine($"- {monitor.GetInfo()}"));
    }
}

// Factory Provider - Manages factory creation
public class FactoryProvider
{
    public static ComputerFactory GetFactory(string vendorType)
    {
        return vendorType.ToLower() switch
        {
            "dell" => new DellFactory(),
            "apple" => new AppleFactory(),
            _ => throw new ArgumentException($"Unknown vendor type: {vendorType}")
        };
    }
}

// Script Execution - Main logic for .csx file
Console.WriteLine("=== Abstract Factory Pattern Demo ===\n");

try
{
    // Create Apple store
    var appleFactory = FactoryProvider.GetFactory("apple");
    var appleStore = new ComputerStore(appleFactory);

    Console.WriteLine("📱 APPLE STORE:");
    appleStore.OrderDesktop(8, 16, 512, 24);
    appleStore.OrderLaptop(10, 32, 1024, 14);
    appleStore.OrderMonitor(27, "5K");
    appleStore.ListInventory();

    Console.WriteLine("\n" + new string('=', 50) + "\n");

    // Create Dell store
    var dellFactory = FactoryProvider.GetFactory("dell");
    var dellStore = new ComputerStore(dellFactory);

    Console.WriteLine("💻 DELL STORE:");
    dellStore.OrderDesktop(12, 32, 1024, 27);
    dellStore.OrderLaptop(8, 16, 512, 15);
    dellStore.OrderMonitor(32, "4K");
    dellStore.ListInventory();

    Console.WriteLine("\n=== Pattern Benefits ===");
    Console.WriteLine("✅ Families of related products are guaranteed to be compatible");
    Console.WriteLine("✅ Easy to add new product families (HP, Lenovo, etc.)");
    Console.WriteLine("✅ Client code is decoupled from concrete product classes");
    Console.WriteLine("✅ Single Responsibility: Each factory creates one family");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error: {ex.Message}");
}

Console.WriteLine("\n🎯 Abstract Factory vs Factory Method:");
Console.WriteLine("- Abstract Factory: Creates FAMILIES of related objects");
Console.WriteLine("- Factory Method: Creates SINGLE objects with inheritance");

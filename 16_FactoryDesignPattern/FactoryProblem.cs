// package Factory.Java.Problem;


abstract class Product {
  protected String description = "";
  public abstract void MakeComputer(int cpu, int ram, int storage, int display);
  public String GetInfo() {
    return this.description;
  }
}

class PC : Product {
  public override void MakeComputer(int cpu, int ram, int storage, int display) {
    this.description = $"DELL PC: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
  }
}

class Laptop : Product {
  public override void MakeComputer(int cpu, int ram, int storage, int display) {
    this.description = $"DELL Laptop: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
  }
}

public class Order {
  Product? PlaceOrder(String type, int cpu, int ram, int storage, int display) {

    Product? product = null;
    switch (type) {
      case "PC": 
        product = new PC();
        product.MakeComputer(cpu, ram, storage, display);
        break;
      case "Laptop":
        product = new Laptop();
        product.MakeComputer(cpu, ram, storage, display);
        break;
    }
    return product;
  }


  public static void Main() {
    var order = new Order();
    var computer = order.PlaceOrder("PC", 4, 16, 512, 16);
    Console.WriteLine(computer?.GetInfo());
  }
}


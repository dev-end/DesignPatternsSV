public abstract class Product {
  protected String description = "";
  public abstract void MakeComputer(int cpu, int ram, int storage, int display);
  public String GetInfo() {
    return this.description;
  }
}

public class PC : Product {
  public override void MakeComputer(int cpu, int ram, int storage, int display) {
    this.description = $"DELL PC: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
  }
}

public class Laptop : Product {
  public override void MakeComputer(int cpu, int ram, int storage, int display) {
    this.description = $"DELL Laptop: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
  }
}

public abstract class OrderSystem {
    private List<Product> products = new ();

    protected abstract Product CreateProduct(string type, int cpu, int ram, int storage, int display);
    public Product PlaceOrder(string type, int cpu, int ram, int storage, int display) {
        var product = CreateProduct(type, cpu, ram, storage, display);
        products.Add(product);
        return product;
    }
}

public class Order : OrderSystem {
    private Dictionary <string, Func<Product>> productFactory = new () {
        { "pc", () => new PC() },
        { "laptop", () => new Laptop() }
    };

    protected override Product CreateProduct(string type, int cpu, int ram, int storage, int display) {
        if (productFactory.ContainsKey(type.ToLower())) {
            var product = productFactory[type.ToLower()]();
            product.MakeComputer(cpu, ram, storage, display);
            return product;
        }
        throw new ArgumentException($"Product type {type} not recognized.");
    }
}

class Program{
public static void Main() {
    var order = new Order();
    var computer = order.PlaceOrder("PC", 4, 16, 512, 16);
    var laptop = order.PlaceOrder("Laptop", 4, 16, 512, 16);
    Console.WriteLine(laptop?.GetInfo());
    Console.WriteLine(computer?.GetInfo());
  }
}



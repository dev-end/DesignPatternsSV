
namespace FactoryPattern
{
    public class Creator
    {
        Dictionary<string, Product> devices = new Dictionary<string, Product>() {
            {"Laptop", new Laptop() },
            {"PC", new PC() }
        };

        public Product CreateProduct(string type)
        {
            devices.TryGetValue(type, out Product value);
            return value;
        }
    }
}

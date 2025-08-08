namespace StrategyOrDiPattern
{
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double cartPrice);
    }

    class Product
    {
        public string name;
        public double unitPrice;
        public double quantity;

        public Product(string name, double unitPrice, int quantity)
        {
            this.name = name;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
        }
    }

    class Order
    {
        List<Product> productList = new();
        IDiscountStrategy discountStrategy;

        public void AddProduct(Product product)
        {
            productList.Add(product);
        }

        public List<Product> GetProductList()
        {
            return productList;
        }

        public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            this.discountStrategy = discountStrategy;
        }

        public void CheckOut()
        {
            double total = 0;
            double discount = 0;
            foreach (var product in productList)
            {
                total += product.unitPrice * product.quantity;
            }

            //if (discountStrategy == "no discount")
            //{
            //    discount = 0;
            //}
            //else if (discountStrategy == "standard discount")
            //{
            //    discount = total * .10;
            //}
            //else if (discountStrategy == "high value discount")
            //{
            //    if (total > 1000)
            //    {
            //        discount = total * .20;
            //    }
            //    else
            //    {
            //        discount = total * .10;
            //    }
            //}
            //else if (discountStrategy == "vip discount")
            //{
            //    discount = total * .30;
            //}

            discount = this.discountStrategy.CalculateDiscount(total);

            System.Console.WriteLine("Order details");
            foreach (var product in productList)
            {
                System.Console.WriteLine($"{product.name} {product.unitPrice} {product.quantity} {product.unitPrice * product.quantity}");
            }
            System.Console.WriteLine($"Amount: {total}", total);
            System.Console.WriteLine($"Discount: {discount}");
            System.Console.WriteLine($"Net: {total - discount}");
        }
    }

    public class StrategyDemo
    {
        public static void Main(string[] args)
        {
            var order = new Order();
            order.AddProduct(new Product("iPhone", 1_00_000, 1));
            order.AddProduct(new Product("AirPods", 30_000, 2));
            order.AddProduct(new Product("Macbook", 2_20_000, 1));

            order.SetDiscountStrategy(new VipDiscount());
            order.CheckOut();
        }
    }

    class NoDiscount : IDiscountStrategy
    {
        double IDiscountStrategy.CalculateDiscount(double cartPrice)
        {
            return cartPrice;
        }
    }

    class StandardDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double cartPrice)
        {
            return cartPrice * 0.10;
        }
    }

    class HighValueDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double cartPrice)
        {
            double discountedPrice = 0;
            if(cartPrice > 1000)
            {
                return discountedPrice = discountedPrice * 0.20;
            }
            else
            {
                return discountedPrice = discountedPrice * 0.10;
            }
        }
    }

    class VipDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double cartPrice)
        {
            return cartPrice * 0.30;
        }
    }

}

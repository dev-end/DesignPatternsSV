using System.ComponentModel.Design;

namespace CommandDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CommandDesignPattern_AKA_Delaying");

            // continue...
        }
    }

    interface IStockMarket
    {
        public void Buy(String stock, int quantity);
        public void Sell(String stock, int quantity);   
    }

    interface ICommandBuy
    {
        public void Buy();
    }

    interface ICommandSell
    {
        public void Sell();
    }

    public class BuyCommand : ICommandBuy
    {
        IStockMarket StockMarket;
        string stock;
        int quantity;
        BuyCommand(string stock, IStockMarket stockMarket)
        {
            this.stock = stock;
            this.StockMarket = stockMarket;
        }

        public void Buy()
        {
            StockMarket.Buy(stock, quantity);
        }
    }

    public class SellCommand : ICommandSell
    {
        IStockMarket StockMarket;
        string stock;
        int quantity;
        SellCommand(string stock, IStockMarket stockMarket)
        {
            this.stock = stock;
            this.StockMarket = stockMarket;
        }

        public void Sell()
        {
            StockMarket.Sell(stock, quantity);
        }
    }

    class BSE : IStockMarket
    {
        public void Buy(String stock, int quantity)
        {
            Console.WriteLine($"Buying {quantity} shares of {stock} on BSE");
        }

        public void Sell(String stock, int quantity)
        {
            Console.WriteLine($"Selling {quantity} shares of {stock} on BSE");
        }
    }

    class NSE : IStockMarket
    {
        public void Buy(String stock, int quantity)
        {
            Console.WriteLine($"Buying {quantity} shares of {stock} on BSE");
        }

        public void Sell(String stock, int quantity)
        {
            Console.WriteLine($"Selling {quantity} shares of {stock} on BSE");
        }
    }

    class Broker
    {
        public Queue<ICommandSell> SellCommandQueue = new Queue<ICommandSell>();
        public Queue<ICommandBuy> BuyCommandQueue = new Queue<ICommandBuy>(); 
        public void AddSellCommands(ICommandSell commandSell)
        {
            this.SellCommandQueue.Enqueue(commandSell);
        }

        public void AddBuyCommands(ICommandBuy commandBuy)
        {
            this.BuyCommandQueue.Enqueue(commandBuy);
        }

        public void PlaceBuyOrder()
        {
            foreach(ICommandBuy icb in this.BuyCommandQueue)
                icb.Buy();
        }

        public void ProcessSellOrder()
        {
            foreach(ICommandSell ics in this.SellCommandQueue)
                ics.Sell();
        }
    }

    
}

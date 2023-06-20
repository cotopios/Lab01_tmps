using System;
using System.Collections.Generic;

// Interfața pentru observator
public interface IStockObserver
{
    void Update(Stock stock);
}

// Clasa subiect
public class Stock
{
    private string symbol;
    private decimal price;
    private List<IStockObserver> observers = new List<IStockObserver>();

    public Stock(string symbol, decimal price)
    {
        this.symbol = symbol;
        this.price = price;
    }

    public void Attach(IStockObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IStockObserver observer)
    {
        observers.Remove(observer);
    }

    public void SetPrice(decimal newPrice)
    {
        if (newPrice != price)
        {
            price = newPrice;
            Notify();
        }
    }

    private void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(this);
        }
    }

    public string Symbol { get { return symbol; } }
    public decimal Price { get { return price; } }
}

// Clasa observatorului
public class StockObserver : IStockObserver
{
    private string name;

    public StockObserver(string name)
    {
        this.name = name;
    }

    public void Update(Stock stock)
    {
        Console.WriteLine("Observatorul {0} a fost notificat că prețul acțiunii {1} a fost actualizat la {2:C}.", name, stock.Symbol, stock.Price);
    }
}

// Exemplu de utilizare
class Program
{
    static void Main(string[] args)
    {
        // Crearea unui obiect de tip subiect
        Stock stock = new Stock("AAPL", 150.50m);

        // Crearea observatorilor
        StockObserver observer1 = new StockObserver("Investitor 1");
        StockObserver observer2 = new StockObserver("Investitor 2");

        // Adăugarea observatorilor la subiect
        stock.Attach(observer1);
        stock.Attach(observer2);

        // Actualizarea prețului acțiunii
        stock.SetPrice(155.75m);

        // Eliminarea unui observator
        stock.Detach(observer2);

        // Actualizarea prețului acțiunii din nou
        stock.SetPrice(160.20m);
    }
}

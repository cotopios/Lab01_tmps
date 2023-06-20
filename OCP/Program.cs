using System;
using System.Collections.Generic;

namespace OCPExample
{
   
    public interface IProduct
    {
        string Name { get; }
        double Price { get; }
    }

    
    public abstract class Product : IProduct
    {
        public abstract string Name { get; }
        public abstract double Price { get; }
    }

   
    public class Book : Product
    {
        public override string Name => "Carte";
        public override double Price => 29.99;
    }

    public class Paper : Product
    {
        public override string Name => "Hârtie";
        public override double Price => 4.99;
    }

   
    public class Pencil : Product
    {
        public override string Name => "Creion";
        public override double Price => 1.99;
    }

    
    public class PriceCalculator
    {
        public double CalculateTotalPrice(IEnumerable<IProduct> products)
        {
            double totalPrice = 0.0;
            foreach (var product in products)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            List<IProduct> products = new List<IProduct>
            {
                new Book(),
                new Paper(),
                new Pencil()
            };

           
            PriceCalculator priceCalculator = new PriceCalculator();

           
            double totalPrice = priceCalculator.CalculateTotalPrice(products);

            Console.WriteLine($"Prețul total al produselor: {totalPrice}");

            Console.ReadLine();
        }
    }
}

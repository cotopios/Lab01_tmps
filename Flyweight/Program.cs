using System;
using System.Collections.Generic;


public interface ICarFlyweight
{
    void Drive(string color);
}


public class CarFlyweight : ICarFlyweight
{
    private string _model;

    public CarFlyweight(string model)
    {
        _model = model;
    }

    public void Drive(string color)
    {
        Console.WriteLine($"Conducând un {_model} {color}");
    }
}


public class CarFlyweightFactory
{
    private Dictionary<string, ICarFlyweight> _cars;

    public CarFlyweightFactory()
    {
        _cars = new Dictionary<string, ICarFlyweight>();
    }

    public ICarFlyweight GetCar(string model)
    {
        if (!_cars.ContainsKey(model))
        {
            _cars[model] = new CarFlyweight(model);
        }

        return _cars[model];
    }
}

// Exemplu de utilizare
class Program
{
    static void Main(string[] args)
    {
        CarFlyweightFactory factory = new CarFlyweightFactory();

        ICarFlyweight bmw = factory.GetCar("BMW");
        bmw.Drive("albastru");

        
        ICarFlyweight bmw2 = factory.GetCar("BMW");
        bmw2.Drive("roșu");

       
        ICarFlyweight mercedes = factory.GetCar("Mercedes");
        mercedes.Drive("negru");

    
        ICarFlyweight mercedes2 = factory.GetCar("Mercedes");
        mercedes2.Drive("gri");

        Console.ReadLine();
    }
}

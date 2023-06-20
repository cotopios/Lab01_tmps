using System;
using System.Collections.Generic;


public abstract class CarComponent
{
    protected string _name;

    public CarComponent(string name)
    {
        _name = name;
    }

    public abstract void DisplayInfo();
}


public class CarPart : CarComponent
{
    public CarPart(string name) : base(name)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"- {_name}");
    }
}

public class CarComposite : CarComponent
{
    private List<CarComponent> _components;

    public CarComposite(string name) : base(name)
    {
        _components = new List<CarComponent>();
    }

    public void AddComponent(CarComponent component)
    {
        _components.Add(component);
    }

    public void RemoveComponent(CarComponent component)
    {
        _components.Remove(component);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"* {_name}");

        foreach (var component in _components)
        {
            component.DisplayInfo();
        }
    }
}

// Exemplu de utilizare
class Program
{
    static void Main(string[] args)
    {
        
        CarComponent engine = new CarPart("Motor");
        CarComponent body = new CarPart("Caroserie");
        CarComponent wheel1 = new CarPart("Roată 1");
        CarComponent wheel2 = new CarPart("Roată 2");
        CarComponent wheel3 = new CarPart("Roată 3");
        CarComponent wheel4 = new CarPart("Roată 4");

       
        CarComposite wheels = new CarComposite("Roți");
        wheels.AddComponent(wheel1);
        wheels.AddComponent(wheel2);
        wheels.AddComponent(wheel3);
        wheels.AddComponent(wheel4);

       
        CarComposite car = new CarComposite("Mașină");
        car.AddComponent(engine);
        car.AddComponent(body);
        car.AddComponent(wheels);

       
        car.DisplayInfo();

        Console.ReadLine();
    }
}

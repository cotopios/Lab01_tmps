using System;


public interface ICar
{
    string GetDescription();
    double GetCost();
}


public class BasicCar : ICar
{
    public string GetDescription()
    {
        return "Mașină de bază";
    }

    public double GetCost()
    {
        return 20000.0;
    }
}


public abstract class CarDecorator : ICar
{
    protected ICar _car;

    public CarDecorator(ICar car)
    {
        _car = car;
    }

    public virtual string GetDescription()
    {
        return _car.GetDescription();
    }

    public virtual double GetCost()
    {
        return _car.GetCost();
    }
}

public class NavigationSystemDecorator : CarDecorator
{
    public NavigationSystemDecorator(ICar car) : base(car)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, cu sistem de navigație";
    }

    public override double GetCost()
    {
        return base.GetCost() + 2000.0;
    }
}


public class PremiumSoundSystemDecorator : CarDecorator
{
    public PremiumSoundSystemDecorator(ICar car) : base(car)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, cu sistem audio premium";
    }

    public override double GetCost()
    {
        return base.GetCost() + 3000.0;
    }
}

// Exemplu de utilizare
class Program
{
    static void Main(string[] args)
    {
        
        ICar basicCar = new BasicCar();
        Console.WriteLine(basicCar.GetDescription());
        Console.WriteLine($"Cost: {basicCar.GetCost()} LEI");

        Console.WriteLine();

        
        ICar carWithNavigation = new NavigationSystemDecorator(basicCar);
        Console.WriteLine(carWithNavigation.GetDescription());
        Console.WriteLine($"Cost: {carWithNavigation.GetCost()} LEI");

        Console.WriteLine();

        
        ICar carWithPremiumSoundSystem = new PremiumSoundSystemDecorator(basicCar);
        Console.WriteLine(carWithPremiumSoundSystem.GetDescription());
        Console.WriteLine($"Cost: {carWithPremiumSoundSystem.GetCost()} LEI");

        Console.WriteLine();

        
        ICar carWithNavigationAndPremiumSoundSystem = new PremiumSoundSystemDecorator(new NavigationSystemDecorator(basicCar));
        Console.WriteLine(carWithNavigationAndPremiumSoundSystem.GetDescription());
        Console.WriteLine($"Cost: {carWithNavigationAndPremiumSoundSystem.GetCost()} LEI");

        Console.ReadLine();
    }
}

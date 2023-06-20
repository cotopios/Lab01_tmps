
public interface IAnimalFactory
{
    ICarnivore CreateCarnivore();
    IHerbivore CreateHerbivore();
}


public class AfricanAnimalFactory : IAnimalFactory
{
    public ICarnivore CreateCarnivore()
    {
        return new Lion();
    }

    public IHerbivore CreateHerbivore()
    {
        return new Giraffe();
    }
}


public class AmericanAnimalFactory : IAnimalFactory
{
    public ICarnivore CreateCarnivore()
    {
        return new GrizzlyBear();
    }

    public IHerbivore CreateHerbivore()
    {
        return new Bison();
    }
}


public interface ICarnivore
{
    void Eat(IHerbivore herbivore);
}


public class Lion : ICarnivore
{
    public void Eat(IHerbivore herbivore)
    {
        Console.WriteLine($"Leul mananca {herbivore.GetType().Name}");
    }
}


public class GrizzlyBear : ICarnivore
{
    public void Eat(IHerbivore herbivore)
    {
        Console.WriteLine($"Ursul Grizzly  mananca {herbivore.GetType().Name}");
    }
}


public interface IHerbivore
{
    void Eat();
}

public class Giraffe : IHerbivore
{
    public void Eat()
    {
        Console.WriteLine($"Girafa mănâncă frunze dintr-un copac.");
    }
}

public class Bison : IHerbivore
{
    public void Eat()
    {
        Console.WriteLine($"Bison mananca iarba.");
    }
}


class Program
{
    static void Main(string[] args)
    {
        IAnimalFactory factory = new AfricanAnimalFactory();

        ICarnivore lion = factory.CreateCarnivore();
        IHerbivore giraffe = factory.CreateHerbivore();

        lion.Eat(giraffe);
        giraffe.Eat();

        factory = new AmericanAnimalFactory();

        ICarnivore grizzlyBear = factory.CreateCarnivore();
        IHerbivore bison = factory.CreateHerbivore();

        grizzlyBear.Eat(bison);
        bison.Eat();
    }
}

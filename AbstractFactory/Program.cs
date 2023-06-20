// Interfață pentru a crea animale
public interface IAnimalFactory
{
    ICarnivore CreateCarnivore();
    IHerbivore CreateHerbivore();
}

// Implementare pentru animalele africane
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

// Implementare pentru animalele americane
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

// Interfață pentru un animal carnivor
public interface ICarnivore
{
    void Eat(IHerbivore herbivore);
}

// Implementare pentru un leu
public class Lion : ICarnivore
{
    public void Eat(IHerbivore herbivore)
    {
        Console.WriteLine($"Lion eats {herbivore.GetType().Name}");
    }
}

// Implementare pentru un urs grizzly
public class GrizzlyBear : ICarnivore
{
    public void Eat(IHerbivore herbivore)
    {
        Console.WriteLine($"Grizzly Bear eats {herbivore.GetType().Name}");
    }
}

// Interfață pentru un animal erbivor
public interface IHerbivore
{
    void Eat();
}

// Implementare pentru o girafă
public class Giraffe : IHerbivore
{
    public void Eat()
    {
        Console.WriteLine($"Giraffe is eating leaves from a tree.");
    }
}

// Implementare pentru un bizon
public class Bison : IHerbivore
{
    public void Eat()
    {
        Console.WriteLine($"Bison is grazing on grass.");
    }
}

// Exemplu de utilizare
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

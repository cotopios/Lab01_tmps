using System;


interface ICloneableAnimal
{
    ICloneableAnimal Clone();
    void PrintInfo();
}


abstract class Animal : ICloneableAnimal
{
    protected string _species;

    public Animal(string species)
    {
        _species = species;
    }

    public abstract ICloneableAnimal Clone();

    public void PrintInfo()
    {
        Console.WriteLine("Specie: " + _species);
    }
}

class Lion : Animal
{
    public Lion(string species) : base(species)
    {
    }

    public override ICloneableAnimal Clone()
    {
        return new Lion(_species);
    }
}


class Zebra : Animal
{
    public Zebra(string species) : base(species)
    {
    }

    public override ICloneableAnimal Clone()
    {
        return new Zebra(_species);
    }
}


class AnimalCloner
{
    private ICloneableAnimal _prototype;

    public AnimalCloner(ICloneableAnimal prototype)
    {
        _prototype = prototype;
    }

    public ICloneableAnimal CloneAnimal()
    {
        return _prototype.Clone();
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        ICloneableAnimal lionPrototype = new Lion("Panthera leo");
        AnimalCloner lionCloner = new AnimalCloner(lionPrototype);
        ICloneableAnimal clonedLion = lionCloner.CloneAnimal();

        
        Console.WriteLine("Leu Prototype Info:");
        lionPrototype.PrintInfo();
        Console.WriteLine("Clonarea Leu Info:");
        clonedLion.PrintInfo();

        
        ICloneableAnimal zebraPrototype = new Zebra("Zebra");
        AnimalCloner zebraCloner = new AnimalCloner(zebraPrototype);
        ICloneableAnimal clonedZebra = zebraCloner.CloneAnimal();

        
        Console.WriteLine("Zebra Prototype Info:");
        zebraPrototype.PrintInfo();
        Console.WriteLine("Clonarea Zebra Info:");
        clonedZebra.PrintInfo();
    }
}

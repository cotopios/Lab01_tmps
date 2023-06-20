using System;


interface IAnimalFactory
{
    IAnimal CreateAnimal();
}


class Cat : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Miau");
    }
}
class Dog : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Ham");
    }
}


interface IAnimal
{
    void MakeSound();
}


class CatFactory : IAnimalFactory
{
    public IAnimal CreateAnimal()
    {
        return new Cat();
    }
}


class DogFactory : IAnimalFactory
{
    public IAnimal CreateAnimal()
    {  
        return new Dog();
    }
}


class Program
{
    static void Main(string[] args)
    {
      
        IAnimalFactory catFactory = new CatFactory();
        IAnimal cat = catFactory.CreateAnimal();
        cat.MakeSound();

        
        IAnimalFactory dogFactory = new DogFactory();
        IAnimal dog = dogFactory.CreateAnimal();
        dog.MakeSound();
    }
}

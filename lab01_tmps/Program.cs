using System;


class Singleton
{
    private static Singleton Instance;


    private Singleton() { }


    public static Singleton GetInstance()
    {
        if (Instance == null)
        {
            Instance = new Singleton();
        }
        return Instance;
    }

  
    public void DisplayMessage()
    {
        Console.WriteLine("Aceasta este o metodă a clasei Singleton!");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Singleton singleton1 = Singleton.GetInstance();
        Singleton singleton2 = Singleton.GetInstance();

        if (singleton1 == singleton2)
        {
            Console.WriteLine("Ambele instanțe sunt identice!");
        }

        singleton1.DisplayMessage();
    }
}

using System;


public interface IEngine
{
    void Start();
    void Stop();
}


public class Engine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Motorul a pornit.");
    }

    public void Stop()
    {
        Console.WriteLine("Motorul s-a oprit.");
    }
}




public abstract class Car 
{
    protected IEngine _engine;

    public Car(IEngine engine)
    {
        _engine = engine;
    }

    public abstract void Start();
    public abstract void Stop();
}


public class SedanCar : Car
{
    public SedanCar(IEngine engine) : base(engine)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Mașina sedan a pornit.");
        _engine.Start();
    }

    public override void Stop()
    {
        Console.WriteLine("Mașina sedan s-a oprit.");
        _engine.Stop();
    }
}


public class SUVCar : Car
{
    public SUVCar(IEngine engine) : base(engine)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Mașina SUV a pornit.");
        _engine.Start();
    }

    public override void Stop()
    {
        Console.WriteLine("Mașina SUV s-a oprit.");
        _engine.Stop();
    }
}


class Program
{
    static void Main(string[] args)
    {
      
        IEngine engine = new Engine();

        
        Car sedanCar = new SedanCar(engine);
        sedanCar.Start();
        sedanCar.Stop();

        Console.WriteLine();

   
        Car suvCar = new SUVCar(engine);
        suvCar.Start();
        suvCar.Stop();

        Console.ReadLine();
    }
}

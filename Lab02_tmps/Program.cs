
public interface IPaymentSystem
{
    void MakePayment(double amount);
}

public class PaymentSystem : IPaymentSystem
{
    public void MakePayment(double amount)
    {
        Console.WriteLine($"Plată efectuată: {amount} RON");
    }
}


public interface INewPaymentSystem
{
    void PerformPayment(double amount);
}

public class NewPaymentSystem : INewPaymentSystem
{
    public void PerformPayment(double amount)
    {
        Console.WriteLine($"Plată efectuată prin noul sistem de plăți: {amount} RON");
    }
}

public class PaymentSystemAdapter : IPaymentSystem
{
    private readonly INewPaymentSystem _newPaymentSystem;

    public PaymentSystemAdapter(INewPaymentSystem newPaymentSystem)
    {
        _newPaymentSystem = newPaymentSystem;
    }

    public void MakePayment(double amount)
    {
        _newPaymentSystem.PerformPayment(amount);
    }
}




class Program
{
    static void Main(string[] args)
    {
       
        IPaymentSystem existingPaymentSystem = new PaymentSystem();
        existingPaymentSystem.MakePayment(100.0);

        
        INewPaymentSystem newPaymentSystem = new NewPaymentSystem();
        IPaymentSystem paymentSystemAdapter = new PaymentSystemAdapter(newPaymentSystem);
        paymentSystemAdapter.MakePayment(200.0);

        Console.ReadLine();
    }
}
using System;

// Clasa abstractă care definește comportamentul generic al unei cereri de serviciu
public abstract class ServiceRequestHandler
{
    protected ServiceRequestHandler successor;

    public void SetSuccessor(ServiceRequestHandler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(ServiceRequest request);
}

// Handler-ul pentru cererea de serviciu de tip "Autentificare"
public class AuthenticationHandler : ServiceRequestHandler
{
    public override void HandleRequest(ServiceRequest request)
    {
        if (request.Type == ServiceRequestType.Authentication)
        {
            Console.WriteLine("Autentificare realizată cu succes.");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Handler-ul pentru cererea de serviciu de tip "Autorizare"
public class AuthorizationHandler : ServiceRequestHandler
{
    public override void HandleRequest(ServiceRequest request)
    {
        if (request.Type == ServiceRequestType.Authorization)
        {
            Console.WriteLine("Autorizare realizată cu succes.");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Handler-ul pentru cererea de serviciu de tip "Procesare"
public class ProcessingHandler : ServiceRequestHandler
{
    public override void HandleRequest(ServiceRequest request)
    {
        if (request.Type == ServiceRequestType.Processing)
        {
            Console.WriteLine("Cerere de procesare realizată cu succes.");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Enumerare pentru tipurile de cereri de serviciu
public enum ServiceRequestType
{
    Authentication,
    Authorization,
    Processing
}

// Clasa care reprezintă o cerere de serviciu
public class ServiceRequest
{
    public ServiceRequestType Type { get; set; }
}

// Exemplu de utilizare
class Program
{
    static void Main(string[] args)
    {
        // Crearea instanțelor handler-ilor
        ServiceRequestHandler authenticationHandler = new AuthenticationHandler();
        ServiceRequestHandler authorizationHandler = new AuthorizationHandler();
        ServiceRequestHandler processingHandler = new ProcessingHandler();

        // Configurarea lanțului de responsabilitate
        authenticationHandler.SetSuccessor(authorizationHandler);
        authorizationHandler.SetSuccessor(processingHandler);

        // Exemple de cereri de serviciu
        ServiceRequest request1 = new ServiceRequest { Type = ServiceRequestType.Authentication };
        ServiceRequest request2 = new ServiceRequest { Type = ServiceRequestType.Authorization };
        ServiceRequest request3 = new ServiceRequest { Type = ServiceRequestType.Processing };

        // Procesarea cererilor de serviciu
        authenticationHandler.HandleRequest(request1);
        authenticationHandler.HandleRequest(request2);
        authenticationHandler.HandleRequest(request3);

        /*
        Output:
        Autentificare realizată cu succes.
        Autorizare realizată cu succes.
        Cerere de procesare realizată cu succes.
        */
    }
}

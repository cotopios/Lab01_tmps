using System;

namespace SRPExample
{
    
    public interface IMessagePrinter
    {
        void PrintMessage(string message);
    }

   
    public class MessageManager
    {
        private readonly IMessagePrinter printer;

        public MessageManager(IMessagePrinter printer)
        {
            this.printer = printer;
        }

        public void ProcessMessage(string message)
        {
           
            string processedMessage = ProcessMessageInternal(message);
            printer.PrintMessage(processedMessage);
        }

        private string ProcessMessageInternal(string message)
        {
           
            return $"Mesajul procesat: {message.ToUpper()}";
        }
    }

   
    public class ConsoleMessagePrinter : IMessagePrinter
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine($"Mesajul primit: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            IMessagePrinter printer = new ConsoleMessagePrinter();

            
            MessageManager messageManager = new MessageManager(printer);

            
            messageManager.ProcessMessage("Salut!");

            Console.ReadLine();
        }
    }
}

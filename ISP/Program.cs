using System;

namespace ISPExample
{
   
    public interface IPrintable
    {
        void Print();
    }

    
    public interface IScannable
    {
        void Scan();
    }

    public class MultifunctionalPrinter : IPrintable, IScannable
    {
        public void Print()
        {
            Console.WriteLine("Imprimare în curs...");
            
        }

        public void Scan()
        {
            Console.WriteLine("Scanare în curs...");
            
        }
    }

    
    public class PrintOnlyClient
    {
        private readonly IPrintable printer;

        public PrintOnlyClient(IPrintable printer)
        {
            this.printer = printer;
        }

        public void PrintDocument()
        {
            printer.Print();
        }
    }

    
    public class ScanOnlyClient
    {
        private readonly IScannable scanner;

        public ScanOnlyClient(IScannable scanner)
        {
            this.scanner = scanner;
        }

        public void ScanDocument()
        {
            scanner.Scan();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            MultifunctionalPrinter printer = new MultifunctionalPrinter();

           
            PrintOnlyClient printClient = new PrintOnlyClient(printer);
            ScanOnlyClient scanClient = new ScanOnlyClient(printer);

           
            printClient.PrintDocument();

            
            scanClient.ScanDocument();

            Console.ReadLine();
        }
    }
}

using System;

namespace DIPExample
{
    
    public interface IStorageService
    {
        void StoreData(string data);
    }

   
    public class DatabaseStorageService : IStorageService
    {
        public void StoreData(string data)
        {
            Console.WriteLine("Stocare în baza de date: " + data);
            
        }
    }

    
    public class FileStorageService : IStorageService
    {
        public void StoreData(string data)
        {
            Console.WriteLine("Stocare în fișier: " + data);
            
        }
    }

   
    public class DataProcessor
    {
        private readonly IStorageService storageService;

        public DataProcessor(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        public void ProcessData(string data)
        {
            storageService.StoreData(data);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            IStorageService databaseStorage = new DatabaseStorageService();

           
            DataProcessor processor1 = new DataProcessor(databaseStorage);

           
            processor1.ProcessData("Exemplu de dată");

            
            IStorageService fileStorage = new FileStorageService();

            
            DataProcessor processor2 = new DataProcessor(fileStorage);

            
            processor2.ProcessData("Alt exemplu de dată");

            Console.ReadLine();
        }
    }
}

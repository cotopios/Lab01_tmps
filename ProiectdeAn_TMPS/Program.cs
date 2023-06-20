using ProiectdeAn_TMPS;

public class LibraryManager
{
    private static LibraryManager instance;
    List<User> users = new List<User>()

        {
            new User ("admin@mail.com", "1232","1232", true),
            new User("user@mail.com","3211","3211")

        };

    List<LibraryItem> libraryItems = new List<LibraryItem>()
    {
        new Book("Garry Potter","J. K. Rowling"),
        new Book("A Song of Ice and Fire","George R. R. Martin"),
        new Magazine("Amic","Iepure"),
        new ReservationDecorator (new Book ("Book1","Author1")),
         new ReservationDecorator (new Book ("Book2","Author2"))


    };

    private LibraryManager() { }

    public static LibraryManager GetInstance()
    {
        if (instance == null)
        {
            instance = new LibraryManager();
        }

        return instance;
    }

    public void Initialize()
    {
        // Initializare bibliotecă online
    }
    public List<User> GetUsers()
    {
        return users;
    }
    public void AddUser(User user)
    {
        if (!users.Contains(user))
        {
            users.Add(user);
        }
    }
    public List<LibraryItem> GetItems()
    {
        return libraryItems;
    }
    public void AddItem(LibraryItem libraryItem)
    {
        if (!libraryItems.Contains(libraryItem))
        {
            libraryItems.Add(libraryItem);
        }
    }

}

// Factory
public abstract class LibraryItem
{
    public abstract void Display();
    public string name { get; set; }
    public string author { get; set; }

    public LibraryItem(string name = null, string author = null)
    {
        this.name = name;
        this.author = author;
    }
}

public class Book : LibraryItem
{
    public Book(string name = null, string author = null) : base(name, author)
    {

    }
    public override void Display()
    {
        Console.WriteLine("Afisare carte");
        Console.WriteLine("\tTitlu: " + name);
        Console.WriteLine("\tAutor: " + author);

    }
}

public class Magazine : LibraryItem
{
    public Magazine(string name = null, string author = null) : base(name, author)
    {

    }
    public override void Display()
    {
        Console.WriteLine("Afisare revista");
        Console.WriteLine("\tDenumire: " + name);
        Console.WriteLine("\tAutor: " + author);

    }
}

public class LibraryItemFactory
{

    public LibraryItem CreateLibraryItem(string type)
    {

        switch (type)
        {
            case "book":
                return new Book();
            case "magazine":
                return new Magazine();
            default:
                throw new ArgumentException("Tip de obiect nevalid");
        }

    }
}

// Decorator
public abstract class LibraryItemDecorator : LibraryItem
{
    protected LibraryItem libraryItem;

    public LibraryItemDecorator(LibraryItem libraryItem) : base(libraryItem.name, libraryItem.author)
    {
        this.libraryItem = libraryItem;
    }

    public override void Display()
    {
        libraryItem.Display();
    }
}

public class ReservationDecorator : LibraryItemDecorator
{
    public ReservationDecorator(LibraryItem libraryItem) : base(libraryItem) { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("--- Acest obiect este rezervat ---");
    }
}

public class RatingDecorator : LibraryItemDecorator
{
    public RatingDecorator(LibraryItem libraryItem) : base(libraryItem) { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Opțiune rating adăugată");
    }
}

// Proxy
public class LibraryItemProxy : LibraryItem
{
    protected LibraryItem libraryItem;
    private bool isAdmin = false;

    public LibraryItemProxy(LibraryItem libraryItem, bool isAdmin = false)
    {
        this.libraryItem = libraryItem;
        this.isAdmin = isAdmin;
    }
    public override void Display()
    {
        Console.WriteLine("Noile detalii :");
        Console.WriteLine("\tTitlu: " + libraryItem.name);
        Console.WriteLine("\tAutor: " + libraryItem.author);

    }

    public void Edit()
    {

        if (HasAccess(isAdmin))
        {
            Console.WriteLine("Introduceti noul nume");
            libraryItem.name = Console.ReadLine();

            Console.WriteLine("Introduceti noul autor");
            libraryItem.author = Console.ReadLine();
            Display();
        }
        else
        {
            Console.WriteLine("Accesul la acest obiect este restricționat");
        }
    }

    protected bool HasAccess(bool isAdmin)
    {
        return isAdmin;
    }
}



// Observer
public interface ILibraryObserver
{
    void Update(LibraryItem newItem);
}
public interface ILibraryPublisher
{
    void RegisterObserver(ILibraryObserver observer);
    void UnregisterObserver(ILibraryObserver observer);
    void NotifyObservers(LibraryItem newItem);
}

public class Library : ILibraryPublisher
{
    //private List<LibraryItem> items = new List<LibraryItem>();
    private List<ILibraryObserver> observers = new List<ILibraryObserver>();

    public Library()
    {
        var obs = LibraryManager.GetInstance().GetUsers();
        foreach (var user in obs)
        {
            if (!user.isAdmin)
            {
                observers.Add(user);
            }
        }
    }
    
    public void RegisterObserver(ILibraryObserver observer)
    {
        //var tmp = observers.FirstOrDefault(u => u.GetType().Name);
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void UnregisterObserver(ILibraryObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(LibraryItem newItem)
    {
        foreach (var observer in observers)
        {
            observer.Update(newItem);
        }
    }
}


// Strategy
public interface ISortStrategy
{
    void Sort(List<LibraryItem> items);
}

public class TitleSortStrategy : ISortStrategy
{
    public void Sort(List<LibraryItem> items)
    {
        items.Sort((item1, item2) => item1.name.CompareTo(item2.name));
    }
}

public class AuthorSortStrategy : ISortStrategy
{
    public void Sort(List<LibraryItem> items)
    {
        items.Sort((item1, item2) => item1.author.CompareTo(item2.author));
    }
}

public class LibraryApp// : ILibraryObserver
{
    private LibraryManager libraryManager;
    private ILibraryPublisher libraryPublisher;
    private LibraryItemFactory itemFactory;
    private Library library;

    public LibraryApp()
    {
        libraryManager = LibraryManager.GetInstance();
        //libraryManager.Initialize();
        libraryPublisher = new Library();
        itemFactory = new LibraryItemFactory();
        library = new Library();

        // Înregistrare observatori pentru notificări
        //library.RegisterObserver(this);
    }

    public void Run()
    {

        List<User> users = libraryManager.GetUsers();
        

        List<LibraryItem> libraryItems = libraryManager.GetItems();
     
        bool isLoggedIn = false;
        User userLogged = null;
       
        do
        {
            userLogged = Login(users);
            if (userLogged != null)
            {
                if (!userLogged.isAdmin)
                {
                    libraryPublisher.RegisterObserver(userLogged);
                }

                
                isLoggedIn = true;
                Console.WriteLine("\n---- Logged as {0} ----\n", userLogged.email);
                // Aplicație de consolă

                // Utilizare Singleton
                //LibraryManager manager = LibraryManager.GetInstance();

                if (!userLogged.isAdmin && userLogged.notification != null)
                {
                    Console.WriteLine("-----   Notificare -----");
                    Console.WriteLine(userLogged.notification);
                    Console.WriteLine();
                }


                ShowMenu();


                string option = Console.ReadLine();
                //while(option != "6") { 
                do
                {
                    switch (option)
                    {
                        case "1":
                            if (libraryItems.Count(item => item is Book /*|| item is ReservationDecorator && (item as ReservationDecorator) is Book*/) > 0)
                            {

                                Console.WriteLine("1.Afisare dupa denumire");
                                Console.WriteLine("2.Afisare dupa autor");
                                var sort = Console.ReadLine();
                                ISortStrategy sortingStrategy = null;
                                if (sort == "1")
                                {
                                    sortingStrategy = new TitleSortStrategy();
                                    sortingStrategy.Sort(libraryItems);
                                }
                                else
                                {
                                    sortingStrategy = new AuthorSortStrategy();
                                    sortingStrategy.Sort(libraryItems);

                                }
                                Console.WriteLine("Obiectele din librarie");
                                foreach (LibraryItem item in libraryItems)
                                {
                                    if (item.GetType().Name == "Book" || item.GetType().Name == "ReservationDecorator")
                                    {
                                        item.Display();
                                    }

                                }
                            }
                            else
                                Console.WriteLine("Nu sunt carti in librarie");
                            break;
                        case "2":
                            if (libraryItems.Count(item => item is Magazine) > 0)
                            {
                                foreach (LibraryItem item in libraryItems)
                                {
                                    if (item.GetType().Name == "Magazine")
                                    {
                                        item.Display();
                                    }

                                }
                            }
                            else
                                Console.WriteLine("Nu sunt  ziare in librarie");

                            break;
                        case "3":
                            if (userLogged.isAdmin)
                            {
                                string type = "book";
                                Console.WriteLine("Ce  doriti sa adaugati ?");
                                Console.WriteLine("1.Carte");
                                Console.WriteLine("2.Ziar");
                                string tip = Console.ReadLine();
                                if (tip == "2")
                                {
                                    type = "magazine";

                                }

                                LibraryItemFactory itemFactory = new LibraryItemFactory();
                                LibraryItem libraryItem = itemFactory.CreateLibraryItem(type);
                                Console.WriteLine("Numele cartii");
                                libraryItem.name = Console.ReadLine();
                                Console.WriteLine("Numele Autorului");
                                libraryItem.author = Console.ReadLine();
                                libraryItems.Add(libraryItem);
                                libraryPublisher.NotifyObservers(libraryItem);
                                foreach (LibraryItem lItem in libraryItems)
                                {
                                    lItem.Display();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Acces interzis");

                            }
                            break;
                        case "4":
                            {
                                foreach (LibraryItem lItem in libraryItems)
                                {
                                    lItem.Display();
                                }
                                Console.WriteLine("Introduce numele cartii");
                                string nameBk = Console.ReadLine();
                                var item = libraryItems.FirstOrDefault(i => i.name == nameBk);
                                var adminAccessBook = new LibraryItemProxy(item, userLogged.isAdmin);
                                adminAccessBook.Edit();
                            }
                            break;
                        ///return new Magazine();
                        case "5":
                            {
                                isLoggedIn = false;
                                Logout();
                                break;
                            }
                        default:
                            throw new ArgumentException("Tip de obiect nevalid");
                    }
                    if (isLoggedIn)
                    {
                        ShowMenu();
                        option = Console.ReadLine();
                    }
                    else option = "0";
                }

                while (option != "0");
                
            }
            else
            {
                Console.WriteLine("Emailul dat nu exista");
            }
        }
        while (!isLoggedIn);




    }

   
    private User Login(List<User> users)
    {
        User user = new User();

        Console.WriteLine("Introduceti emailul");
        user.email = Console.ReadLine();
        Console.WriteLine("Introduceti parola");
        user.password = Console.ReadLine();

        //return users.FirstOrDefault(u => u.email == user.email);
        User userLogged = users.FirstOrDefault(u => u.email == user.email);
        if (userLogged != null && userLogged.password == user.password)
        {
            return userLogged;
        }
        else
        {
            Console.WriteLine("Parola este gresita !!!");
            return null;
        }
    }

    private void Logout()
    {
        Console.WriteLine("Delogat cu succes.\n");
    }
    public void ShowMenu()
    {
        Console.WriteLine("\n1) Afisare Carti");
        Console.WriteLine("2) Afisare Ziare");
        Console.WriteLine("3) Adauga item");
        Console.WriteLine("4) Editeaza item");
        
        Console.WriteLine("5) Log Out");
        Console.Write("\nAlege o optiune: ");
    }
}

class Program
{
    static void Main(string[] args)
    {
        LibraryApp app = new LibraryApp();
        app.Run();
    }
}
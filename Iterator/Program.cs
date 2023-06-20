using System;
using System.Collections;

// Clasa pentru obiectele din bibliotecă
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

// Interfața pentru iterator
public interface IIterator
{
    bool HasNext();
    object Next();
}

// Clasa pentru iteratorul listei de cărți
public class LibraryIterator : IIterator
{
    private Library library;
    private int currentIndex;

    public LibraryIterator(Library library)
    {
        this.library = library;
        currentIndex = 0;
    }

    public bool HasNext()
    {
        return currentIndex < library.Count;
    }

    public object Next()
    {
        if (HasNext())
        {
            object book = library[currentIndex];
            currentIndex++;
            return book;
        }
        return null;
    }
}

// Clasa pentru bibliotecă
public class Library : IEnumerable
{
    private ArrayList books;

    public Library()
    {
        books = new ArrayList();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public int Count
    {
        get { return books.Count; }
    }

    public object this[int index]
    {
        get { return books[index]; }
    }

    public IIterator CreateIterator()
    {
        return new LibraryIterator(this);
    }

    public IEnumerator GetEnumerator()
    {
        return books.GetEnumerator();
    }
}

// Exemplu de utilizare
class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // Adăugarea cărților în bibliotecă
        library.AddBook(new Book("Harry Potter", "J.K. Rowling"));
        library.AddBook(new Book("The Hobbit", "J.R.R. Tolkien"));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));

        // Parcurgerea bibliotecii utilizând iteratorul
        IIterator iterator = library.CreateIterator();
        while (iterator.HasNext())
        {
            Book book = (Book)iterator.Next();
            Console.WriteLine("Titlu: {0}, Autor: {1}", book.Title, book.Author);
        }
    }
}

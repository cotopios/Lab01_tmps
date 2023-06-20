using System;
using System.Collections.Generic;

// Originator - Clasa care creează și restaurează obiectele Memento
public class DrawingEditor
{
    private List<string> shapes = new List<string>();

    public void AddShape(string shape)
    {
        shapes.Add(shape);
    }

    public void PrintShapes()
    {
        Console.WriteLine("Formele din desen:");
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }

    public DrawingMemento CreateMemento()
    {
        return new DrawingMemento(shapes);
    }

    public void RestoreMemento(DrawingMemento memento)
    {
        shapes = memento.GetState();
    }
}

// Memento - Clasa care reține starea obiectului Originator
public class DrawingMemento
{
    private List<string> savedShapes;

    public DrawingMemento(List<string> shapes)
    {
        savedShapes = new List<string>(shapes);
    }

    public List<string> GetState()
    {
        return savedShapes;
    }
}

// Caretaker - Clasa care gestionează Memento-uri și interacțiunea cu Originatorul
public class UndoManager
{
    private Stack<DrawingMemento> mementos = new Stack<DrawingMemento>();

    public void SaveMemento(DrawingMemento memento)
    {
        mementos.Push(memento);
    }

    public DrawingMemento Undo()
    {
        if (mementos.Count > 0)
        {
            return mementos.Pop();
        }
        return null;
    }
}

// Exemplu de utilizare
class Program
{
    static void Main(string[] args)
    {
        DrawingEditor editor = new DrawingEditor();
        UndoManager undoManager = new UndoManager();

        editor.AddShape("Cerc");
        editor.AddShape("Dreptunghi");
        editor.PrintShapes();  // Output: Formele din desen: Cerc, Dreptunghi

        // Salvăm starea curentă a desenului utilizând Memento
        DrawingMemento memento = editor.CreateMemento();
        undoManager.SaveMemento(memento);

        editor.AddShape("Triunghi");
        editor.PrintShapes();  // Output: Formele din desen: Cerc, Dreptunghi, Triunghi

        // Facem undo pentru a reveni la starea anterioară
        DrawingMemento previousMemento = undoManager.Undo();
        if (previousMemento != null)
        {
            editor.RestoreMemento(previousMemento);
        }

        editor.PrintShapes();  // Output: Formele din desen: Cerc, Dreptunghi
    }
}

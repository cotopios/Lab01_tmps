using System;
using System.Collections.Generic;

// Interfața de comandă
public interface ICommand
{
    void Execute();
    void Undo();
}

// Comanda pentru inserarea textului
public class InsertCommand : ICommand
{
    private readonly TextEditor textEditor;
    private readonly string text;
    private int position;

    public InsertCommand(TextEditor editor, string text, int position)
    {
        textEditor = editor;
        this.text = text;
        this.position = position;
    }

    public void Execute()
    {
        textEditor.InsertText(text, position);
    }

    public void Undo()
    {
        textEditor.DeleteText(position, text.Length);
    }
}

// Comanda pentru ștergerea textului
public class DeleteCommand : ICommand
{
    private readonly TextEditor textEditor;
    private string deletedText;
    private int position;

    public DeleteCommand(TextEditor editor, int position, int length)
    {
        textEditor = editor;
        this.position = position;
        deletedText = textEditor.GetText(position, length);
    }

    public void Execute()
    {
        textEditor.DeleteText(position, deletedText.Length);
    }

    public void Undo()
    {
        textEditor.InsertText(deletedText, position);
    }
}

// Clasa Editorului de Text
public class TextEditor
{
    private string text = "";

    public void InsertText(string textToInsert, int position)
    {
        text = text.Insert(position, textToInsert);
        Console.WriteLine("Textul '{0}' a fost inserat la poziția {1}.", textToInsert, position);
    }

    public void DeleteText(int position, int length)
    {
        string deletedText = text.Substring(position, length);
        text = text.Remove(position, length);
        Console.WriteLine("Textul '{0}' a fost șters de la poziția {1}.", deletedText, position);
    }

    public string GetText(int position, int length)
    {
        return text.Substring(position, length);
    }

    public void PrintText()
    {
        Console.WriteLine("Textul curent: {0}", text);
    }
}

// Invoker
public class TextEditorInvoker
{
    private readonly List<ICommand> commandHistory = new List<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Add(command);
    }

    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            var lastCommand = commandHistory[commandHistory.Count - 1];
            lastCommand.Undo();
            commandHistory.Remove(lastCommand);
        }
    }
}

// Exemplu de utilizare
class Program
{
    static void Main(string[] args)
    {
        TextEditor textEditor = new TextEditor();
        TextEditorInvoker invoker = new TextEditorInvoker();

        invoker.ExecuteCommand(new InsertCommand(textEditor, "Hello", 0));
        invoker.ExecuteCommand(new InsertCommand(textEditor, " World", 5));
        textEditor.PrintText();  // Output: Textul curent: Hello World

        invoker.ExecuteCommand(new DeleteCommand(textEditor, 6, 5));
        textEditor.PrintText();  // Output: Textul curent: Hello

        invoker.UndoLastCommand();
        textEditor.PrintText();  // Output: Textul curent: Hello World
    }
}

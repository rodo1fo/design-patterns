using System.Collections.Generic;
using System.Windows.Input;

// Definition: Encapsulate a request as an object, thereby letting you parameterize clients with different requests,
// queue or log requests, and support undoable operations.

namespace Design.Patterns.Behavioral.CommandSample
{
    public abstract class Command
    {
        protected readonly Application App;
        protected readonly Editor Editor;
        private string _backup;

        protected Command(Application app, Editor editor)
        {
            App = app;
            Editor = editor;
        }

        protected void SaveBackup()
        {
            _backup = Editor.Text;
        }

        public void Undo()
        {
            Editor.Text = _backup;
        }

        public abstract bool Execute();
    }

    class CopyCommand : Command
    {
        public CopyCommand(Application app, Editor editor) : base(app, editor)
        {
        }

        public override bool Execute()
        {
            App.Clipboard = Editor.GetSelection();
            return false;
        }
    }

    class CutCommand : Command
    {
        public CutCommand(Application app, Editor editor) : base(app, editor)
        {
        }

        public override bool Execute()
        {
            SaveBackup();
            App.Clipboard = Editor.GetSelection();
            Editor.DeleteSelection();
            return true;
        }
    }

    class PasteCommand : Command
    {
        public PasteCommand(Application app, Editor editor) : base(app, editor)
        {
        }

        public override bool Execute()
        {
            SaveBackup();
            Editor.ReplaceSelection(App.Clipboard);
            return true;
        }
    }

    class UndoCommand : Command
    {
        public UndoCommand(Application app, Editor editor) : base(app, editor)
        {
        }

        public override bool Execute()
        {
            App.Undo();
            return false;
        }
    }

    // Receiver
    public class Editor
    {
        public string Text;

        public string GetSelection()
        {
            return "";
        }

        public void DeleteSelection()
        {
        }

        public void ReplaceSelection(string text)
        {
        }
    }

    // Invoker
    public class Application
    {
        public string Clipboard;
        private readonly Editor _activeEditor = new Editor();
        private readonly Stack<Command> _history = new Stack<Command>();

        public Command Copy, Cut, Paste;

        public Application()
        {
            Copy = ExecuteCommand(new CopyCommand(this, _activeEditor));

            Cut = ExecuteCommand(new CutCommand(this, _activeEditor));

            Paste = ExecuteCommand(new PasteCommand(this, _activeEditor));

            //Undo = ExecuteCommand(new UndoCommand(this, _activeEditor));
        }

        private Command ExecuteCommand(Command command)
        {
            if (command.Execute())
                _history.Push(command);

            return command;
        }

        public void Undo()
        {
            var command = _history.Pop();
            if (command != null)
                command.Undo();
        }
    }

    public class TestCommand
    {
        public void Run()
        {
            var app = new Application();
            app.Clipboard = "super test";

            app.Copy.Execute();
            app.Paste.Execute();
            app.Undo();
        }
    }
}
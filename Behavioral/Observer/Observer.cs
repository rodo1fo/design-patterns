using System.Collections.Generic;
using System.IO;

// Definition: Define a one-to-many dependency between objects so that when one object changes state,
// all its dependents are notified and updated automatically.
namespace Design.Patterns.Behavioral.Observer
{
    class EventManager
    {
        private readonly Dictionary<string, List<IEventListener>> _listeners;

        public EventManager()
        {
            _listeners = new Dictionary<string, List<IEventListener>>();
        }

        public void Subscribe(string eventType, IEventListener listener)
        {
            if(!_listeners.ContainsKey(eventType))
                _listeners.Add(eventType, new List<IEventListener>());
            
            _listeners[eventType].Add(listener);
        }

        public void Unsubscribe(string eventType, IEventListener listener)
        {
            _listeners[eventType].Remove(listener);
        }

        public void Notify(string eventType, string data)
        {
            foreach (var listener in _listeners[eventType])
                listener.Update(data);
        }
    }

    class TextEditor
    {
        public readonly EventManager Events;
        private Stream _file;
        private string _fileName;

        public TextEditor()
        {
            Events = new EventManager();
        }

        public void OpenFile(string path)
        {
            _file = File.Open(path, FileMode.Append);
            _fileName = Path.GetFileName(path);
            Events.Notify("open", _fileName);
        }

        public void SaveFile()
        {
            _file.Write(null);
            Events.Notify("save", _fileName);
        }
    }

    interface IEventListener
    {
        void Update(string filename);
    }

    class LoggingListener : IEventListener
    {
        private readonly string _logFile;
        private readonly string _message;

        public LoggingListener(string logFile, string message)
        {
            _logFile = logFile;
            _message = message;
        }

        public void Update(string filename)
        {
            File.WriteAllText(_logFile, filename + _message);
        }
    }

    class EmailAlertsListener : IEventListener
    {
        private string _email;
        private string _message;

        public EmailAlertsListener(string email, string message)
        {
            _email = email;
            _message = message;
        }

        public void Update(string filename)
        {
            //sendMail(email, filename, message)
        }
    }

    public class TestObserver
    {
        public void Run()
        {
            var editor = new TextEditor();

            var logger = new LoggingListener("/path/to/log.txt", "Someone has opened the file: %s");
            editor.Events.Subscribe("open", logger);

            var emailAlerts = new EmailAlertsListener("admin@example.com", "Someone has changed the file: %s");
            editor.Events.Subscribe("save", emailAlerts);

            editor.OpenFile("c:/file");
            editor.SaveFile();
            
            editor.Events.Unsubscribe("save", emailAlerts);
            editor.SaveFile();
        }
    }
}
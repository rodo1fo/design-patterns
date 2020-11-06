using System;
using System.Collections.Generic;
using System.Linq;

// Definition: Provide a way to access the elements of an aggregate object sequentially
// without exposing its underlying representation.

namespace Design.Patterns.Behavioral.Iterator
{
    public interface ISubjects
    {
        IIterator CreateIterator();
    }

    public class Science : ISubjects
    {
        private readonly LinkedList<string> _subjects;

        public Science()
        {
            _subjects = new LinkedList<string>();
            _subjects.AddFirst("Maths");
            _subjects.AddFirst("Comp. Sc.");
            _subjects.AddFirst("Physics");
        }

        public IIterator CreateIterator()
        {
            return new ScienceIterator(_subjects);
        }
    }

    public class Arts : ISubjects
    {
        private readonly string[] _subjects;

        public Arts()
        {
            _subjects = new[] {"Bengali", "English"};
        }

        public IIterator CreateIterator()
        {
            return new ArtsIterator(_subjects);
        }
    }

    public interface IIterator
    {
        void First(); //Reset to first element
        string Next(); //Get next element
        bool IsDone(); //End of collection check
        string CurrentItem(); //Retrieve Current Item
    }

    public class ScienceIterator : IIterator
    {
        private readonly LinkedList<string> _subjects;
        private int _position;

        public ScienceIterator(LinkedList<string> subjects)
        {
            _subjects = subjects;
            _position = 0;
        }

        public void First()
        {
            _position = 0;
        }

        public string Next()
        {
            return _subjects.ElementAt(_position++);
        }

        public bool IsDone()
        {
            if (_position < _subjects.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string CurrentItem()
        {
            return _subjects.ElementAt(_position);
        }
    }

    public class ArtsIterator : IIterator
    {
        private readonly string[] _subjects;
        private int _position;

        public ArtsIterator(string[] subjects)
        {
            _subjects = subjects;
            _position = 0;
        }

        public void First()
        {
            _position = 0;
        }

        public string Next()
        {
            return _subjects[_position++];
        }

        public bool IsDone()
        {
            return _position >= _subjects.Length;
        }

        public string CurrentItem()
        {
            return _subjects[_position];
        }
    }

    class TestIterator
    {
        static void Run()
        {
            Console.WriteLine("***Iterator Pattern Demo***");
            ISubjects scienceSubjects = new Science();
            ISubjects artsSubjects = new Arts();
            IIterator iteratorForScience = scienceSubjects.CreateIterator();
            IIterator iteratorForArts = artsSubjects.CreateIterator();
            
            Console.WriteLine("\nScience subjects :");
            Print(iteratorForScience);
            
            Console.WriteLine("\nArts subjects :");
            Print(iteratorForArts);
            
            Console.ReadLine();
        }

        private static void Print(IIterator iterator)
        {
            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
using System;

// Definition: Provide a surrogate or placeholder for another object to control access to it.

namespace Design.Patterns.Structural.ProxySample
{
    public abstract class Subject
    {
        public abstract void DoSomeWork();
    }

    /// <summary>
    /// ConcreteSubject class
    /// </summary>
    public class ConcreteSubject : Subject
    {
        public override void DoSomeWork()
        {
            Console.WriteLine("ConcreteSubject.DoSomeWork()");
        }
    }

    /// <summary>
    /// Proxy class
    /// </summary>
    public class Proxy : Subject
    {
        Subject _cs;

        public override void DoSomeWork()
        {
            Console.WriteLine("Proxy call happening now...");
            //Lazy initialization:We'll not instantiate until the method is //called
            // not thread safe, go to multithread Singleton to see how to implement a thread safe version.  
            if (_cs == null)
            {
                _cs = new ConcreteSubject();
            }

            _cs.DoSomeWork();
        }
    }

    class TestProxy
    {
        static void Run()
        {
            Console.WriteLine("***Proxy Pattern Demo***\n");
            Proxy px = new Proxy();
            px.DoSomeWork();
            Console.ReadKey();
        }
    }
}
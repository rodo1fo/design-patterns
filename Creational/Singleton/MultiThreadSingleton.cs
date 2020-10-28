using System;

namespace Design.Patterns.Creational.SingletonSample
{
    public sealed class MultiThreadSingleton
    {
        //We are using volatile to ensure that
        //assignment to the instance variable finishes before it’s //access.
        private static volatile MultiThreadSingleton _instance;
        private static object lockObject = new Object();

        private MultiThreadSingleton()
        {
        }

        public static MultiThreadSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                            _instance = new MultiThreadSingleton();
                    }
                }

                return _instance;
            }
        }
    }
}
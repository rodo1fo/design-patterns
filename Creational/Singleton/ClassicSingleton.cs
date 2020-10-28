using System;

// definition:
// Ensure a class has only one instance, and provide a global point of access to it.

namespace Design.Patterns.Creational.SingletonSample
{
    public class ClassicSingleton
    {
        private static ClassicSingleton _instance;

        private ClassicSingleton()
        {
        }

        public static ClassicSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClassicSingleton();
                }

                return _instance;
            }
        }
    }
}
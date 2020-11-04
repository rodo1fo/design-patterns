using System;

// Definition: Define a family of algorithms, encapsulate each one, and make them interchangeable.
// Strategy lets the algorithm vary independently from clients that use it.
namespace Design.Patterns.Behavioral.StrategySample
{
    interface IStrategy
    {
        int Execute(int a, int b);
    }

    class ConcreteStrategyAdd : IStrategy
    {
        public int Execute(int a, int b)
        {
            return a + b;
        }
    }

    class ConcreteStrategySubtract : IStrategy
    {
        public int Execute(int a, int b)
        {
            return a - b;
        }
    }

    class ConcreteStrategyMultiply : IStrategy
    {
        public int Execute(int a, int b)
        {
            return a * b;
        }
    }

    class Context
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public int ExecuteStrategy(int a, int b)
        {
            return _strategy.Execute(a, b);
        }
    }

    class TestStrategy
    {
        void Run()
        {
            string action = "addition";

            var context = new Context();

            switch (action)
            {
                case "addition": 
                    context.SetStrategy(new ConcreteStrategyAdd());
                    break;
                
                case "subtraction": 
                    context.SetStrategy(new ConcreteStrategySubtract());
                    break;
                
                case "multiplication": 
                    context.SetStrategy(new ConcreteStrategyMultiply());
                    break;
            }

            var result = context.ExecuteStrategy(5, 3);

            Console.WriteLine(result);
        }
    }
}
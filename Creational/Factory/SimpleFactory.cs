using System;

// Definition: Create an object without exposing the instantiation logic to the client.
namespace Design.Patterns.Creational.Factory.SimpleFactorySample
{
    public interface IAnimal
    {
        void Speak();
        void Action();
    }

    public class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Dog says: Bow-Wow.");
        }

        public void Action()
        {
            Console.WriteLine("Dogs prefer barking...");
        }
    }

    public class Tiger : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Tiger says: Halum.");
        }

        public void Action()
        {
            Console.WriteLine("Tigers prefer hunting...");
        }
    }

    public abstract class ISimpleFactory
    {
        public abstract IAnimal CreateAnimal(string animal);
    }

    public class SimpleFactory : ISimpleFactory
    {
        public override IAnimal CreateAnimal(string animal)
        {
            IAnimal intendedAnimal = animal.ToLower() switch
            {
                "dog" => new Dog(),
                "tiger" => new Tiger(),
                _ => throw new ApplicationException(" Unknown Animal cannot be instantiated")
            };

            return intendedAnimal;
        }
    }

    class TestSimpleFactory
    {
        static void Run()
        {
            IAnimal preferredType = null;
            ISimpleFactory simpleFactory = new SimpleFactory();

            #region The code region that will vary based on users preference
            preferredType = simpleFactory.CreateAnimal(Console.ReadLine());
            #endregion

            #region The codes that do not change frequently
            preferredType.Speak();
            preferredType.Action();
            #endregion

            Console.ReadKey();
        }
    }
}
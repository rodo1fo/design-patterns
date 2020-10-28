using System;

// definition:
// Specify the kinds of objects to create using a prototypical instance,
// and create new objects by copying this prototype.

namespace Design.Patterns.Creational.PrototypeSample
{
    public abstract class BasicCar
    {
        public string ModelName { get; set; }
        public int Price { get; set; }

        public static int SetPrice()
        {
            var price = 0;
            var r = new Random();
            var p = r.Next(200000, 500000);
            price = p;
            return price;
        }

        public abstract BasicCar Clone();
    }

    public class Nano : BasicCar
    {
        public Nano(string m)
        {
            ModelName = m;
        }

        public override BasicCar Clone()
        {
            return (Nano) this.MemberwiseClone();
        }
    }

    public class Ford : BasicCar
    {
        public Ford(string m)
        {
            ModelName = m;
        }

        public override BasicCar Clone()
        {
            return (Ford) this.MemberwiseClone();
        }
    }

    public class TestPrototype
    {
        public void Run()
        {
            Console.WriteLine("***Prototype Pattern Demo***\n");

            //Base or Original Copy
            BasicCar nanoBase = new Nano("Green Nano") {Price = 100000};
            BasicCar fordBase = new Ford("Ford Yellow") {Price = 500000};

            BasicCar bc1;
            //Nano
            bc1 = nanoBase.Clone();
            bc1.Price = nanoBase.Price + BasicCar.SetPrice();
            Console.WriteLine("Car is: {0}, and it's price is Rs. {1} ", bc1.ModelName, bc1.Price);

            //Ford
            bc1 = fordBase.Clone();
            bc1.Price = fordBase.Price + BasicCar.SetPrice();
            Console.WriteLine("Car is: {0}, and it's price is Rs. {1}", bc1.ModelName, bc1.Price);
            Console.ReadLine();
        }
    }
}
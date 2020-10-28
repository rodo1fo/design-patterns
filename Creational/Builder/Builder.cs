using System;
using System.Collections.Generic;

// definition:
// Separate the construction of a complex object from its representation
// so that the same construction processes can create different representations.

namespace Design.Patterns.Creational.BuilderSample
{
    interface IBuilder
    {
        void StartUpOperations();
        void BuildBody();
        void InsertWheels();
        void AddHeadlights();
        void EndOperations();
        Product GetVehicle();
    }

    // ConcreteBuilder: Car
    class CarBuilder : IBuilder
    {
        private string brandName;
        private Product product;

        public CarBuilder(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }

        public void StartUpOperations()
        {
            //Starting with brandname
            product.Add(string.Format("Car Model name :{0}", this.brandName));
        }

        public void BuildBody()
        {
            product.Add("This is a body of a Car");
        }

        public void InsertWheels()
        {
            product.Add("4 wheels are added");
        }

        public void AddHeadlights()
        {
            product.Add("2 Headlights are added");
        }

        public void EndOperations()
        {
            //Nothing in this case
        }

        public Product GetVehicle()
        {
            return product;
        }
    }

    // ConcreteBuilder:Motorcycle
    class MotorCycleBuilder : IBuilder
    {
        private string brandName;
        private Product product;

        public MotorCycleBuilder(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }

        public void StartUpOperations()
        {
            //Nothing in this case
        }

        public void BuildBody()
        {
            product.Add("This is a body of a Motorcycle");
        }

        public void InsertWheels()
        {
            product.Add("2 wheels are added");
        }

        public void AddHeadlights()
        {
            product.Add("1 Headlights are added");
        }

        public void EndOperations()
        {
            //Finishing up with brandname
            product.Add(string.Format("Motorcycle Model name :{0}", this.brandName));
        }

        public Product GetVehicle()
        {
            return product;
        }
    }

    // "Product"
    class Product
    {
        // We can use any data structure that you prefer e.g.List<string> etc.
        private LinkedList<string> parts;

        public Product()
        {
            parts = new LinkedList<string>();
        }

        public void Add(string part)
        {
            //Adding parts
            parts.AddLast(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct completed as below :");
            foreach (string part in parts)
                Console.WriteLine(part);
        }
    }

    // "Director"
    class Director
    {
        private IBuilder _builder;

        // A series of steps-in real life, steps are complex.
        public void Construct(IBuilder builder)
        {
            this._builder = builder;
            builder.StartUpOperations();
            builder.BuildBody();
            builder.InsertWheels();
            builder.AddHeadlights();
            builder.EndOperations();
        }
    }

    class TestBuilder
    {
        public void Run(string[] args)
        {
            Console.WriteLine("***Builder Pattern Demo***");
            var director = new Director();
            IBuilder b1 = new CarBuilder("Ford");
            IBuilder b2 = new MotorCycleBuilder("Honda");

            // Making Car
            director.Construct(b1);
            Product p1 = b1.GetVehicle();
            p1.Show();

            //Making MotorCycle
            director.Construct(b2);
            Product p2 = b2.GetVehicle();
            p2.Show();

            Console.ReadLine();
        }
    }
}
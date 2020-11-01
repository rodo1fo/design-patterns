using System;
using System.Collections.Generic;

// Definition: Compose objects into tree structures to represent part-whole hierarchies.
// Composite lets clients treat individual objects and compositions of objects uniformly
namespace Design.Patterns.Structural.Composite.Sample
{
    interface IEmployee
    {
        void PrintStructures();
    }

    class CompositeEmployee : IEmployee
    {
        private readonly string _name;

        private readonly string _dept;

        //The container for child objects
        private readonly List<IEmployee> _controls;

        // constructor
        public CompositeEmployee(string name, string dept)
        {
            _name = name;
            _dept = dept;
            _controls = new List<IEmployee>();
        }

        public void Add(IEmployee e)
        {
            _controls.Add(e);
        }

        public void Remove(IEmployee e)
        {
            _controls.Remove(e);
        }

        public void PrintStructures()
        {
            Console.WriteLine("\t" + _name + "works in" + _dept);
            foreach (IEmployee e in _controls)
            {
                e.PrintStructures();
            }
        }
    }

    class Employee : IEmployee
    {
        private readonly string _name;

        private readonly string _dept;

        // constructor
        public Employee(string name, string dept)
        {
            _name = name;
            _dept = dept;
        }

        public void PrintStructures()
        {
            Console.WriteLine("\t\t" + _name + "works in" + _dept);
        }
    }

    class TestComposite
    {
        static void Run()
        {
            Console.WriteLine("***Composite Pattern Demo ***"); //Principal of the college
            
            var principal = new CompositeEmployee("Dr.S.Som (Principal)", "Planning-Supervising-Managing");
            
            // The College has 2 Head of Departments-One from Mathematics, One from Computer Sc.
            var hodMaths = new CompositeEmployee("Mrs.S.Das(HOD-Maths)", "Maths");
            var hodCompSc = new CompositeEmployee("Mr. V.Sarcar(HOD-CSE)", "Computer Sc.");
            
            // 2 other teachers works in Mathematics department
            var mathTeacher1 = new Employee("Math Teacher-1", "Maths");
            var mathTeacher2 = new Employee("Math Teacher-2", "Maths");
            
            // 3 other teachers works in Computer Sc. department
            var cseTeacher1 = new Employee("CSE Teacher-1", "Computer Sc.");
            var cseTeacher2 = new Employee("CSE Teacher-2", "Computer Sc.");
            var cseTeacher3 = new Employee("CSE Teacher-3", "Computer Sc.");
            
            // Teachers of Mathematics directly reports to HOD-Maths
            hodMaths.Add(mathTeacher1);
            hodMaths.Add(mathTeacher2);
            
            // Teachers of Computer Sc. directly reports to HOD-CSE
            hodCompSc.Add(cseTeacher1);
            hodCompSc.Add(cseTeacher2);
            hodCompSc.Add(cseTeacher3);

            // Principal is on top of college
            // HOD -Maths and Comp. Sc directly reports to him
            principal.Add(hodMaths);
            principal.Add(hodCompSc);
            
            // Printing the leaf-nodes and branches in the same way.
            // i.e. in each case, we are calling PrintStructures() method
            Console.WriteLine("\n Testing the structure of a Principal object");
            
            // Prints the complete structure
            principal.PrintStructures();
            Console.WriteLine("\n Testing the structure of a HOD object:");
            Console.WriteLine("Teachers working at Computer Science department:");
            
            // Prints the details of Computer Sc, department
            hodCompSc.PrintStructures();
            
            // Leaf node
            Console.WriteLine("\n Testing the structure of a leaf node:");
            mathTeacher1.PrintStructures();
            
            // Suppose, one computer teacher is leaving now from the organization.
            hodCompSc.Remove(cseTeacher2);
            Console.WriteLine("\n After CSE Teacher-2 resigned, the organization has following members:");
            principal.PrintStructures();
            
            Console.ReadKey();
        }
    }
}
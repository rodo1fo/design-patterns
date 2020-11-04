// Definition: Define the skeleton of an algorithm in an operation, deferring some steps to subclasses.
// The Template Method pattern lets subclasses redefine certain steps of an algorithm without changing the algorithm’s structure.

using System;

namespace Design.Patterns.Behavioral.TemplateSample
{
    public abstract class BasicEngineering
    {
        public void Papers()
        {
            //Common Papers:
            Math();
            SoftSkills();
            if (IsAdditionalPapersNeeded())
            {
                AdditionalPapers();
            }

            //Specialized Paper:
            SpecialPaper();
        }

        private void Math()
        {
            Console.WriteLine("Mathematics");
        }

        private void SoftSkills()
        {
            Console.WriteLine("SoftSkills");
        }

        private void AdditionalPapers()
        {
            Console.WriteLine("AdditionalPapers are needed in this stream.");
        }

        public abstract void SpecialPaper();

        //A hook method-Additional Papers not needed.
        public virtual bool IsAdditionalPapersNeeded()
        {
            return true;
        }
    }

    public class ComputerScience : BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("Object-Oriented Programming");
        }

        //Not tested the hook method:
        //Additional papers are needed
    }

    public class Electronics : BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("Digital Logic and Circuit Theory");
        }

        //Using the hook method
        public override bool IsAdditionalPapersNeeded()
        {
            return false;
        }
    }

    class TestTemplate
    {
        static void Run()
        {
            Console.WriteLine("***Template Method Pattern QAs***\n");
            
            Console.WriteLine("Computer Sc Papers:");
            BasicEngineering bs = new ComputerScience();
            bs.Papers();
            Console.WriteLine();
            
            Console.WriteLine("Electronics Papers:");
            bs = new Electronics();
            bs.Papers();
            Console.ReadLine();
        }
    }
}
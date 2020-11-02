using System;

// Definition: Decouple an abstraction from its implementation so that the two can vary independently.

namespace Design.Patterns.Structural.BridgeSample
{
    //Implementor
    public interface IState
    {
        void MoveState();
    }

    //ConcreteImplementor-1
    public class OnState : IState
    {
        public void MoveState()
        {
            Console.Write("On State");
        }
    }

    //ConcreteImplementor-2
    public class OffState : IState
    {
        public void MoveState()
        {
            Console.Write("Off State");
        }
    }

    //Abstraction
    public abstract class ElectronicGoods
    {
        //Composition - implementor
        protected IState State { get; }

        protected ElectronicGoods(IState state)
        {
            State = state;
        }

        public abstract void MoveToCurrentState();
    }

    //Refined Abstraction
    public class Television : ElectronicGoods
    {
        public Television(IState state) : base(state)
        {
        }

        // Implementation specific:
        // We are delegating the implementation to the Implementor object
        public override void MoveToCurrentState()
        {
            Console.Write("\n Television is functioning at : ");
            State.MoveState();
        }
    }

    public class VCD : ElectronicGoods
    {
        public VCD(IState state) : base(state)
        {
        }

        /*Implementation specific:
        * We are delegating the implementation to the Implementor object*/
        public override void MoveToCurrentState()
        {
            Console.Write("\n VCD is functioning at : ");
            State.MoveState();
        }
    }

    class TestBridge
    {
        static void Run()
        {
            Console.WriteLine("***Bridge Pattern Demo***");
            Console.WriteLine("\nDealing with a Television:");

            IState presentState = new OnState();
            ElectronicGoods eItem = new Television(presentState);
            eItem.MoveToCurrentState();

            //Verifying Off state of the Television now
            presentState = new OffState();
            eItem = new Television(presentState);
            eItem.MoveToCurrentState();

            Console.WriteLine("\n \n Dealing with a VCD:");
            
            presentState = new OnState();
            eItem = new VCD(presentState);
            eItem.MoveToCurrentState();

            presentState = new OffState();
            eItem = new VCD(presentState);
            eItem.MoveToCurrentState();
            
            Console.ReadLine();
        }
    }
}
using System;
using Design.Patterns.Structural.FacadeSample.FacadePattern;
using Another.Company.Project.RobotParts;

// Definition: Provide a unified interface to a set of interfaces in a subsystem.
// Facade defines a higher-level interface that makes the subsystem easier to use.
namespace Another.Company.Project.RobotParts
{
    public class RobotBody
    {
        public void CreateHands()
        {
            Console.WriteLine("Hands manufactured");
        }

        public void CreateRemainingParts()
        {
            Console.WriteLine("Remaining parts (other than hands) are created");
        }

        public void DestroyHands()
        {
            Console.WriteLine("The robot's hands are destroyed");
        }

        public void DestroyRemainingParts()
        {
            Console.WriteLine("The robot's remaining parts are destroyed");
        }
    }

    public class RobotColor
    {
        public void SetDefaultColor()
        {
            Console.WriteLine("This is steel color robot.");
        }

        public void SetGreenColor()
        {
            Console.WriteLine("This is a green color robot.");
        }
    }

    public class RobotHands
    {
        public void SetMilanoHands()
        {
            Console.WriteLine("The robot will have EH1 Milano hands");
        }

        public void SetRobonautHands()
        {
            Console.WriteLine("The robot will have Robonaut hands");
        }

        public void ResetMilanoHands()
        {
            Console.WriteLine("EH1 Milano hands are about to be destroyed");
        }

        public void ResetRobonautHands()
        {
            Console.WriteLine("Robonaut hands are about to be destroyed");
        }
    }
}

namespace Design.Patterns.Structural.FacadeSample.FacadePattern
{
    public class RobotFacade
    {
        RobotColor rc;
        RobotHands rh;
        RobotBody rb;

        public RobotFacade()
        {
            rc = new RobotColor();
            rh = new RobotHands();
            rb = new RobotBody();
        }

        public void ConstructMilanoRobot()
        {
            Console.WriteLine("Creation of a Milano Robot Start");
            rc.SetDefaultColor();
            rh.SetMilanoHands();
            rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine("Milano Robot Creation End");
            Console.WriteLine();
        }

        public void ConstructRobonautRobot()
        {
            Console.WriteLine("Initiating the creational process of a Robonaut Robot");
            rc.SetGreenColor();
            rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine("A Robonaut Robot is created");
            Console.WriteLine();
        }

        public void DestroyMilanoRobot()
        {
            Console.WriteLine("Milano Robot's destruction process is started");
            rh.ResetMilanoHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();
            Console.WriteLine("Milano Robot's destruction process is over");
            Console.WriteLine();
        }

        public void DestroyRobonautRobot()
        {
            Console.WriteLine("Initiating a Robonaut Robot's destruction process.");
            rh.ResetRobonautHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();
            Console.WriteLine("A Robonaut Robot is destroyed");
            Console.WriteLine();
        }
    }
}

namespace Design.Patterns.Structural.FacadeSample
{
    class TestFacade
    {
        static void Run()
        {
            Console.WriteLine("***Facade Pattern Demo***\n");

            //Creating Robots
            RobotFacade rf1 = new RobotFacade();
            rf1.ConstructMilanoRobot();
            RobotFacade rf2 = new RobotFacade();
            rf2.ConstructRobonautRobot();

            //Destroying robots
            rf1.DestroyMilanoRobot();
            rf2.DestroyRobonautRobot();
            Console.ReadLine();
        }
    }
}
using System.Collections.Generic;

// Definition: Represent an operation to be performed on the elements of an object structure. 
// Visitor lets you define a new operation without changing the classes of the elements on which it operates.
namespace Design.Patterns.Behavioral.VisitorPattern
{
    interface IShape
    {
        void Move(int x, int y);
        void Draw();
        void Accept(IVisitor v);
    }

    public class Dot : IShape
    {
        public void Move(int x, int y)
        {
            // Move dot
        }

        public void Draw()
        {
            // Draw dot
        }

        void IShape.Accept(IVisitor v)
        {
            v.VisitDot(this);
        }
    }

    class Circle : IShape
    {
        public void Move(int x, int y)
        {
            // Move circle
        }

        public void Draw()
        {
            // Draw circle
        }

        public void Accept(IVisitor v)
        {
            v.VisitCircle(this);
        }
    }

    class Rectangle : IShape
    {
        public void Move(int x, int y)
        {
            // Move rectangle
        }

        public void Draw()
        {
            // Draw rectangle
        }

        public void Accept(IVisitor v)
        {
            v.VisitRectangle(this);
        }
    }

    class CompoundShape : IShape
    {
        public void Move(int x, int y)
        {
        }

        public void Draw()
        {
        }

        public void Accept(IVisitor v)
        {
            v.VisitCompoundShape(this);
        }
    }

    interface IVisitor
    {
        void VisitDot(Dot d);
        void VisitCircle(Circle c);
        void VisitRectangle(Rectangle r);
        void VisitCompoundShape(CompoundShape cs);
    }

    class XMLExportVisitor : IVisitor
    {
        public void VisitDot(Dot d)
        {
            // export dot to xml
        }

        public void VisitCircle(Circle c)
        {
            // export circle to xml
        }

        public void VisitRectangle(Rectangle r)
        {
            // export rectangle to xml
        }

        public void VisitCompoundShape(CompoundShape cs)
        {
            // export compoundShape to xml
        }
    }

    public class TestVisitor
    {
        public void Run()
        {
            var allShapes = new List<IShape>()
            {
                new Circle(),
                new Dot(),
                new Rectangle(),
                new CompoundShape()
            };

            var exportVisitor = new XMLExportVisitor();

            foreach (var shape in allShapes)
                shape.Accept(exportVisitor);
        }
    }
}
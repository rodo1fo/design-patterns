using System;

// Convert the interface of a class into another interface that clients expect.
// The Adapter pattern lets classes work together that could not otherwise because of incompatible interfaces.
namespace Design.Patterns.Structural.AdapterSample
{
    internal class RoundHole
    {
        private readonly int _radius;

        public RoundHole(int radius)
        {
            _radius = radius;
        }

        public bool Fits(RoundPeg peg)
        {
            return _radius >= peg.Radius;
        }
    }

    internal class RoundPeg
    {
        public double Radius { get; }

        public RoundPeg()
        {
        }

        public RoundPeg(int radius)
        {
            Radius = radius;
        }
    }

    internal class SquarePeg
    {
        public int Width { get; }

        public SquarePeg(int width)
        {
            Width = width;
        }
    }

    internal class SquarePegAdapter : RoundPeg
    {
        private readonly SquarePeg _peg;

        public SquarePegAdapter(SquarePeg peg)
        {
            _peg = peg;
        }

        public new double Radius => _peg.Width * Math.Sqrt(2) / 2;
    }

    internal class TestAdapter
    {
        static void Run()
        {
            Console.WriteLine("***Adapter Pattern Demo***\n");

            var hole = new RoundHole(5);
            var roundPeg = new RoundPeg(5);
            hole.Fits(roundPeg); // true

            var smallSquarePeg = new SquarePeg(5);
            var largeSquarePeg = new SquarePeg(10);

            // don't compile (incompatible types).
            //hole.Fits(smallSquarePeg);

            var smallSquarePegAdapter = new SquarePegAdapter(smallSquarePeg);
            var largeSquarePegAdapter = new SquarePegAdapter(largeSquarePeg);
            hole.Fits(smallSquarePegAdapter); // true
            hole.Fits(largeSquarePegAdapter); // false
        }
    }
}
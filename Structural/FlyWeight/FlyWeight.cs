using System;
using System.Collections.Generic;
using System.Drawing;

namespace Design.Patterns.Structural.FlyWeightSample
{
    public class TreeType
    {
        public string Name { get; }
        public string Color { get; }
        public string Texture { get; }

        public TreeType(string name, string color, string texture)
        {
            Name = name;
            Color = color;
            Texture = texture;
        }

        public void Draw(Rectangle canvas, Point position)
        {
            Console.Out.WriteLine($"X: {position.X} Y:{position.Y}");
        }
    }

    public static class TreeFactory
    {
        private static readonly List<TreeType> TreeTypes = new List<TreeType>();

        public static TreeType GetTreeType(string name, string color, string texture)
        {
            var type = TreeTypes.Find(x => x.Name == name && x.Color == color && x.Texture == texture);
            if (type == null)
            {
                type = new TreeType(name, color, texture);
                TreeTypes.Add(type);
            }

            return type;
        }
    }

    public class Tree
    {
        private readonly Point _position;
        private readonly TreeType _type;

        public Tree(Point position, TreeType type)
        {
            _position = position;
            _type = type;
        }

        public void Draw(Rectangle canvas)
        {
            _type.Draw(canvas, _position);
        }
    }

    public class Forest
    {
        private readonly List<Tree> _trees;

        public Forest()
        {
            _trees = new List<Tree>();
        }

        public void PlantTree(Point position, string name, string color, string texture)
        {
            var type = TreeFactory.GetTreeType(name, color, texture);
            var tree = new Tree(position, type);
            _trees.Add(tree);
        }

        public void Draw(Rectangle canvas)
        {
            foreach (var tree in _trees)
                tree.Draw(canvas);
        }
    }
    
    class TestFlyWeight
    {
        static void Run()
        {
            Console.WriteLine("***FlyWeight Pattern Demo***\n");
            
            var forest = new Forest();
            forest.PlantTree(new Point(1,2), "tree 1 (large obj 1.1)", "blue (large obj 1.2)", "large obj 1.3" );
            forest.PlantTree(new Point(10,20), "tree 2 (large obj 2.1)", "blue (large obj 2.2)", "large obj 2.3" );
            forest.PlantTree(new Point(11,21), "tree 2 (large obj 2.1)", "blue (large obj 2.2)", "large obj 2.3" );
            forest.PlantTree(new Point(12,22), "tree 2 (large obj 2.1)", "blue (large obj 2.2)", "large obj 2.3" );
            forest.PlantTree(new Point(100,200), "tree 3 (large obj 3.1)", "blue (large obj 3.2)", "large obj 3.3" );
            forest.PlantTree(new Point(101,201), "tree 3 (large obj 3.1)", "blue (large obj 3.2)", "large obj 3.3" );
            forest.PlantTree(new Point(102,202), "tree 3 (large obj 3.1)", "blue (large obj 3.2)", "large obj 3.3" );

            forest.Draw(new Rectangle());
            Console.ReadLine();
        }
    }
}
namespace LCA
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static readonly Random random = new Random(100);

        private const int MainDeep = 10;

        public static void Main(string[] args)
        {
            var root = CreateTree(MainDeep);
            Console.WriteLine("Hello World!" + root.Value);
            PrintTree(root, MainDeep);
            Console.WriteLine("Hello World!");
            Console.Read();
        }

        private static Node CreateTree(int deep)
        {
            if (deep == 0)
            {
                return null;
            }

            var root = new Node(random.Next(1, 99))
            {
                Left = CreateTree(deep - 1),
                Right = CreateTree(deep - 1)
            };

            return root;
        }

        private static void PrintTree(Node root, int deep)
        {
            // have to use queue
            Console.WriteLine(new string(' ', (deep - 1) * 5) + root.Value + $"(deep:{MainDeep - deep})");
            if (root.Left != null)
            {
                PrintTree(root.Left, deep - 1);
            }
            if (root.Right != null)
            {
                PrintTree(root.Right, deep - 1);
            }
        }
    }

    internal class Node
    {
        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node(int value)
        {
            this.Value = value;
        }
    }
}
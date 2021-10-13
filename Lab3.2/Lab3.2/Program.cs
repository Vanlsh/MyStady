using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;



namespace Lab3._2
{
    class Program
    {
        static void Main()
        {
            List<Vector> vectors = new List<Vector>();

            vectors.Add(new Vector(new Color(128, 128, 128), 0, 2));
            vectors.Add(new Vector(new Color(12, 12, 34), 15, 3));
            vectors.Add(new Vector(new Color(56, 23, 12), 45, 4));
            vectors.Add(new Vector(new Color(45, 13, 255), 90, 5));
            vectors.Add(new Vector(new Color(255, 255, 255), 180, 6));

            foreach (var vector in vectors)
            {
                if (vector.Length == 3)
                {
                    vectors.Remove(vector);
                    break;
                }
            }
            foreach (var vector in vectors)
            {
                if (vector.Angle == 90)
                {
                    vector.Angle = 95;
                }
            }

            BinaryTree<Vector> binaryTree = new BinaryTree<Vector>();

            foreach (var vector in vectors)
            {
                binaryTree.Add(vector);
            }

            Console.WriteLine("Tree depth: " + binaryTree.GetTreeDepth());


            IEnumerator iterator = binaryTree.GetEnumerator();

            do
            {
                (iterator.Current as Vector).PrntInfo();
            }
            while (iterator.MoveNext());


            Console.ReadLine();
        }
    }
}
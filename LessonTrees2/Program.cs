using Supercluster.KDTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTrees2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[], double> L2Norm = (x, y) =>
            {
                double dist = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    dist += (x[i] - y[i]) * (x[i] - y[i]);
                }

                return dist;
            };

            int[][] points = new[]
            {
                new[] {2, 3},
                new[] {1, 7},
                new[] {4, 6},
                new[] {9, 7},
                new[] {6, 4},
                new[] {5, 3},
                new[] {8, 9},
                new[] {9, 10},
            };

            string[] gameObjects = new string[]
            {
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",
            };

            KDTree<int, string> tree = new KDTree<int, string>(2, points, gameObjects, L2Norm);
            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Dimensions);
            var result = tree.NearestNeighbors(new[] { 9, 9 }, 3);

            foreach (Tuple<int[], string> point in result)
            {

                Console.WriteLine("({0},{1}) - {2}", point.Item1[0], point.Item1[1], point.Item2);
            }
            Console.WriteLine(tree.Navigator.Right.Right.Node);



        }
    }
}

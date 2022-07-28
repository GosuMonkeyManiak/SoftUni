namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static string[,] graph;
        private static HashSet<int> visited;
        private static Dictionary<int, int> nodeSums;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new string[n, n];
            visited = new HashSet<int>();
            nodeSums = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                string adjacentNodes = Console.ReadLine();

                for (int j = 0; j < adjacentNodes.Length; j++)
                {
                    graph[i, j] = adjacentNodes[j].ToString();
                }
            }

            for (int node = 0; node < graph.GetLength(0); node++)
            {
                DFS(node);
            }

            Console.WriteLine(nodeSums.Sum(x => x.Value));
        }

        static int DFS(int node)
        {
            if (visited.Contains(node))
            {
                return nodeSums[node];
            }

            visited.Add(node);

            bool isHaveRelation = false;
            int currentNodeSum = 0;

            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[node, i] == "Y")
                {
                    isHaveRelation = true;
                    currentNodeSum += DFS(i);
                }
            }

            if (isHaveRelation)
            {
                nodeSums.Add(node, currentNodeSum);
                return currentNodeSum;
            }

            nodeSums.Add(node, 1);
            return 1;
        }
    }
}
namespace ConnectComp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                List<int> currentNodeAdjacent = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (currentNodeAdjacent.Count == 0)
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    graph[i] = currentNodeAdjacent;
                }
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                List<int> component = new List<int>();

                DFS(i, component);

                Console.WriteLine($"Connected component: {string.Join(" ", component)}");
            }
        }

        static void DFS(int node, List<int> componentCollection)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var adjacentNode in graph[node])
            {
                DFS(adjacentNode, componentCollection);
            }

            componentCollection.Add(node);
        }
    }
}
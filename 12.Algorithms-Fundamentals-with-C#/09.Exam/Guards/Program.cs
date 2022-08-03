namespace Guards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;

        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<int>>();
            visited = new HashSet<int>();

            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            for (int i = 0; i < e; i++)
            {
                string[] edge = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int from = int.Parse(edge[0]);
                int to = int.Parse(edge[1]);

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<int>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<int>());
                }

                graph[from].Add(to);
            }

            int start = int.Parse(Console.ReadLine());

            DFS(start);

            List<int> notVisited = new List<int>();

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    notVisited.Add(node);
                }
            }

            notVisited = notVisited
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(" ", notVisited));
        }

        static void DFS(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var adjacentNodes in graph[node])
            {
                DFS(adjacentNodes);
            }
        }
    }
}
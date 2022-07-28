namespace CyclesInAGraph
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static List<string> cycle;

        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycle = new List<string>();

            while (true)
            {
                string[] edgeParts = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                if (edgeParts[0] == "End")
                {
                    break;
                }

                string source = edgeParts[0];
                string destination = edgeParts[1];

                if (!graph.ContainsKey(source))
                {
                    graph.Add(source, new List<string>());
                }

                if (!graph.ContainsKey(destination))
                {
                    graph.Add(destination, new List<string>());
                }

                graph[source].Add(destination);
            }

            bool isAcyclic = true;

            try
            {
                foreach (var node in graph.Keys)
                {
                    if (!visited.Contains(node))
                    {
                        DFS(node);
                    }
                }
            }
            catch (Exception)
            {
                isAcyclic = false;
            }

            string result = isAcyclic ? "Yes" : "No";

            Console.WriteLine($"Acyclic: {result}");
        }

        static void DFS(string node)
        {
            if (cycle.Contains(node))
            {
                throw new Exception();
            }

            cycle.Add(node);
            visited.Add(node);

            foreach (var adjacentNode in graph[node])
            {
                DFS(adjacentNode);
            }

            cycle.Remove(node);
        }
    }
}
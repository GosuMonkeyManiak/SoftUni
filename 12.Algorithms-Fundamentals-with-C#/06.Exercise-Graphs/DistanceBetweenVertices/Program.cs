namespace DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static string[] pairs;
        private static HashSet<int> visited;
        private static Dictionary<int, int> path;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            path = new Dictionary<int, int>();
            visited = new HashSet<int>();
            graph = ReadGraph(n);
            pairs = ReadParis(p);

            for (int i = 0; i < pairs.Length; i++)
            {
                Tuple<int, int> pair = ParsePair(pairs[i]);

                visited.Clear();
                path.Clear();
                int neededSteps = BFS(pair.Item1, pair.Item2);

                Console.WriteLine($"{{{pair.Item1}, {pair.Item2}}} -> {neededSteps}");
            }
        }

        static int BFS(int start, int end)
        {
            Queue<int> nodes = new Queue<int>();
            nodes.Enqueue(start);

            path.Add(start, -1);

            bool isFound = false;

            while (nodes.Count > 0)
            {
                int removeNode = nodes.Dequeue();
                visited.Add(removeNode);

                if (removeNode == end)
                {
                    isFound = true;
                    break;
                }

                foreach (var adjacentNode in graph[removeNode])
                {
                    if (!visited.Contains(adjacentNode))
                    {
                        nodes.Enqueue(adjacentNode);
                        visited.Add(adjacentNode);
                        path.Add(adjacentNode, removeNode);
                    }
                }
            }

            if (isFound)
            {
                return ReconstructPath(end);
            }

            return -1;
        }

        static Dictionary<int, List<int>> ReadGraph(int n)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] edgeParts = Console.ReadLine()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                int source = int.Parse(edgeParts[0]);

                if (edgeParts.Length == 1)
                {
                    graph.Add(source, new List<int>());
                }
                else
                {
                    List<int> destinations = edgeParts[1]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                    graph.Add(source, destinations);
                }
            }

            return graph;
        }

        static string[] ReadParis(int p)
        {
            string[] pairs = new string[p];

            for (int i = 0; i < p; i++)
            {
                pairs[i] = Console.ReadLine();
            }

            return pairs;
        }

        static Tuple<int, int> ParsePair(string pair)
        {
            int[] pairParts = pair
                .Split("-", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return new Tuple<int, int>(pairParts[0], pairParts[1]);
        }

        static int ReconstructPath(int end)
        {
            int pathIndex = end;
            int steps = -1;

            while (pathIndex != -1)
            {
                steps++;
                pathIndex = path[pathIndex];
            }

            return steps;
        }
    }
}
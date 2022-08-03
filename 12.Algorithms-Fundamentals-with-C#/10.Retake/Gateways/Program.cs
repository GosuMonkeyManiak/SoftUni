namespace Gateways
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        private static int[] path;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>(n);
            visited = new HashSet<int>();
            path = new int[n + 1];

            Array.Fill(path, -1);

            for (int i = 0; i < e; i++)
            {
                int[] edgeParts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int source = edgeParts[0];
                int destination = edgeParts[1];

                if (!graph.ContainsKey(source))
                {
                    graph.Add(source, new List<int>());
                }

                if (!graph.ContainsKey(destination))
                {
                    graph.Add(destination, new List<int>());
                }

                graph[source].Add(destination);
            }


            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            BFS(start, end);

            if (path[end] != -1)
            {
                var path = RecoverPath(end);
                path.Reverse();
                Console.WriteLine(string.Join(" ", path));
            }
        }

        static void BFS(int start, int end)
        {
            Queue<int> nodes = new Queue<int>();
            nodes.Enqueue(start);

            while (nodes.Count > 0)
            {
                int removeNode = nodes.Dequeue();
                visited.Add(removeNode);

                if (removeNode == end)
                {
                    break;
                }

                foreach (var adjacentNode in graph[removeNode])
                {
                    if (!visited.Contains(adjacentNode))
                    {
                        nodes.Enqueue(adjacentNode);
                        visited.Add(adjacentNode);
                        path[adjacentNode] = removeNode;
                    }
                }
            }
        }
        
        static List<int> RecoverPath(int end)
        {
            List<int> recoveredPath = new List<int>();
            recoveredPath.Add(end);

            int currentPosition = path[end];

            while (currentPosition != -1)
            {
                recoveredPath.Add(currentPosition);
                currentPosition = path[currentPosition];
            }

            return recoveredPath;
        }
    }
}
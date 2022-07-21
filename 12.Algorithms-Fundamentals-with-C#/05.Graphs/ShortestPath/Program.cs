namespace ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] path;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            visited = new bool[n + 1];
            path = new int[n + 1];
            Array.Fill(path, -1);

            for (int i = 0; i < e; i++)
            {
                string[] edgeParts = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                int destination = int.Parse(edgeParts[0]);
                int source = int.Parse(edgeParts[1]);

                if (graph[source] == null)
                {
                    graph[source] = new List<int>();
                }

                if (graph[destination] == null)
                {
                    graph[destination] = new List<int>();
                }

                if (!graph[source].Contains(destination))
                {
                    graph[source].Add(destination);
                }

                if (!graph[destination].Contains(source))
                {
                    graph[destination].Add(source);
                }
            }

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());


            Queue<int> nodes = new Queue<int>();
            nodes.Enqueue(start);

            while (nodes.Count > 0)
            {
                int removeNode = nodes.Dequeue();

                if (removeNode == end)
                {
                    break;
                }
                visited[removeNode] = true;

                foreach (var adjacentNodes in graph[removeNode])
                {
                    if (!visited[adjacentNodes])
                    {
                        nodes.Enqueue(adjacentNodes);
                        visited[adjacentNodes] = true;
                        path[adjacentNodes] = removeNode;
                    }
                }
            }

            Stack<int> reconstructedPath = new Stack<int>();

            int reConstructedIndex = end;

            while (reConstructedIndex != -1)
            {
                reconstructedPath.Push(reConstructedIndex);
                reConstructedIndex = path[reConstructedIndex];
            }

            Console.WriteLine($"Shortest path length is: {reconstructedPath.Count - 1}");
            Console.WriteLine(string.Join(" ", reconstructedPath));
        }
    }
}
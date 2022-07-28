namespace RoadReconstruction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} {this.Second}";
        }
    }

    class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;

        private static List<Edge> importantStreets;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            edges = new List<Edge>(e);

            importantStreets = new List<Edge>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                int[] edgeParts = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeParts[0];
                int secondNode = edgeParts[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                edges.Add(new Edge() { First = firstNode, Second = secondNode });
            }

            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[graph.Length];
                DFS(0);

                if (visited.Contains(false))
                {
                    importantStreets.Add(new Edge
                    {
                        First = Math.Min(edge.First, edge.Second),
                        Second = Math.Max(edge.First, edge.Second)
                    });
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }

            Console.WriteLine("Important streets:");
            importantStreets.ForEach(edge => Console.WriteLine(edge));
        }

        static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var adjacentNode in graph[node])
            {
                DFS(adjacentNode);
            }
        }
    }
}
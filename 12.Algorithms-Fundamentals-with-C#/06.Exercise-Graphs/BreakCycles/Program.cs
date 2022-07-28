namespace BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<KeyValuePair<string, string>> removedEdges;

        private static HashSet<string> visited;
        private static List<string> cycle;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>(n);
            removedEdges = new List<KeyValuePair<string, string>>();

            visited = new HashSet<string>();
            cycle = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] nodeParts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                string source = nodeParts[0];

                graph.Add(source, new List<string>());

                if (nodeParts.Length > 1)
                {
                    List<string> destinations = nodeParts[1]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    graph[source] = destinations;
                }
            }

            graph = graph
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var node in graph.Keys)
            {
                List<string> adjacentNodes = graph[node].OrderBy(x => x).ToList();

                foreach (var adjacentNode in adjacentNodes)
                {
                    visited.Clear();

                    //remove edge
                    graph[node].Remove(adjacentNode);
                    graph[adjacentNode].Remove(node);


                    //start DFS or BFS to find path from node to adjacentNode
                    bool isHasPath = BFS(node, adjacentNode);


                    if (isHasPath)
                    {
                        //is has path from node to adjacentNode add edge to removed
                        removedEdges.Add(new KeyValuePair<string, string>(node, adjacentNode));
                    }
                    else
                    {
                        //is don't has paht from node to adjacentNode restore the edge
                        graph[node].Add(adjacentNode);
                        graph[adjacentNode].Add(node);
                    }
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            Console.WriteLine(string.Join("\n" ,removedEdges.Select(kvp => $"{kvp.Key} - {kvp.Value}")));
        }

        static bool BFS(string start, string end)
        {
            Queue<string> nodes = new Queue<string>();
            nodes.Enqueue(start);

            while (nodes.Count > 0)
            {
                string removedNode = nodes.Dequeue();
                visited.Add(removedNode);

                if (removedNode == end)
                {
                    return true;
                }

                foreach (var adjacentNode in graph[removedNode])
                {
                    if (!visited.Contains(adjacentNode))
                    {
                        nodes.Enqueue(adjacentNode);
                        visited.Add(adjacentNode);
                    }
                }
            }

            return false;
        }
    }
}
namespace SourceRemoval
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            dependencies = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                string node = line[0];

                if (line.Length == 1)
                {
                    graph.Add(node, new List<string>());
                }
                else
                {
                    List<string> adjacentNodes = line[1]
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    graph.Add(node, adjacentNodes);
                }
            }

            foreach (var (node, adjacentNodes) in graph)
            {
                if (!dependencies.ContainsKey(node))
                {
                    dependencies.Add(node, 0);
                }

                foreach (var adjacentNode in adjacentNodes)
                {
                    if (dependencies.ContainsKey(adjacentNode))
                    {
                        dependencies[adjacentNode]++;
                    }
                    else
                    {
                        dependencies[adjacentNode] = 1;
                    }
                }
            }

            List<string> topologicalSorting = new List<string>();

            for (int i = 0; i < graph.Count; i++)
            {
                string currentNodeWithZeroDependencies = dependencies
                    .FirstOrDefault(x => x.Value == 0)
                    .Key;

                if (currentNodeWithZeroDependencies == null)
                {
                    break;
                }

                dependencies.Remove(currentNodeWithZeroDependencies);

                foreach (var adjacentNode in graph[currentNodeWithZeroDependencies])
                {
                    dependencies[adjacentNode]--;
                }

                topologicalSorting.Add(currentNodeWithZeroDependencies);
            }

            if (dependencies.Count != 0)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", topologicalSorting)}");
            }
        }
    }
}

 // Lab 5
// Student name: Eeshal Fatima
// Student number: 76020494

using System;
using System.Collections.Generic;

Console.WriteLine("CPEN223 Lab 5");

// Testing: Write test cases that exercise all four methods you are to implement.
// TODO
//
// end Testing code

// Do not change the program skeleton: keep the class name, method names,
// parameters, and return types exactly as given.
// Do not use LINQ, and do not use Console inside the GraphLibrary methods.

public static class GraphLibrary
{
    /// <summary>
    /// Determines whether an undirected graph is connected.
    /// </summary>
    static bool IsConnected(
        IReadOnlyDictionary<string, HashSet<string>> graph, string start)
    {
        if (graph.Count == 0)
            return true;

        if (!graph.ContainsKey(start))
            throw new ArgumentException("start not in graph");

        HashSet<string> visited = new();
        Stack<string> work = new();
        work.Push(start);

        while (work.Count > 0)
        {
            string v = work.Pop();

            if (!visited.Add(v))
                continue;

            foreach (string n in graph[v])
                work.Push(n);
        }

        return visited.Count == graph.Count;
    }

    public static HashSet<string> ReachableFrom(
        IReadOnlyDictionary<string, HashSet<string>> graph,
        string start)
    {
        if (!graph.ContainsKey(start))
            throw new ArgumentException("start not in graph");

        HashSet<string> visited = new();
        Stack<string> work = new();

        work.Push(start);

        while (work.Count > 0)
        {
            string v = work.Pop();

            if (!visited.Add(v))
                continue;

            foreach (string n in graph[v])
                work.Push(n);
        }

        return visited;
    }

    public static int CountComponents(
        IReadOnlyDictionary<string, HashSet<string>> graph)
    {
        HashSet<string> visited = new();
        int components = 0;

        foreach (string vertex in graph.Keys)
        {
            if (visited.Contains(vertex))
                continue;

            HashSet<string> reachable = ReachableFrom(graph, vertex);

            foreach (string v in reachable)
                visited.Add(v);

            components++;
        }

        return components;
    }

    public static int ShortestDistance(
        IReadOnlyDictionary<string, HashSet<string>> graph,
        string start,
        string target)
    {
        if (!graph.ContainsKey(start) || !graph.ContainsKey(target))
            throw new ArgumentException("start or target not in graph");

        if (start == target)
            return 0;

        HashSet<string> visited = new();
        Queue<string> work = new();
        Dictionary<string, int> distance = new();

        work.Enqueue(start);
        visited.Add(start);
        distance[start] = 0;

        while (work.Count > 0)
        {
            string v = work.Dequeue();

            foreach (string n in graph[v])
            {
                if (visited.Contains(n))
                    continue;

                visited.Add(n);
                distance[n] = distance[v] + 1;

                if (n == target)
                    return distance[n];

                work.Enqueue(n);
            }
        }

        return -1;
    }
}

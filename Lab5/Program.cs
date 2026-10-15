// Lab 5
// Student name:
// Student number:

using System;
using System.Collections.Generic;

Console.WriteLine("CPEN223 Lab 5");

//Testing: Write test cases that exercise all four methods you are to implement.
//TODO
//
//
//end Testing code

//Do not change the program skeleton: keep the class name, method names,
//parameters, and return types exactly as given.
//Do not use LINQ, and do not use Console inside the GraphLibrary methods.

public static class GraphLibrary
{
    /// <summary>
    /// Determines whether an undirected graph is connected.
    /// The graph is connected if every vertex can be reached from <paramref name="start"/>
    /// by following zero or more edges.
    /// An empty graph is considered connected.
    /// </summary>
    /// <param name="graph">
    /// The graph, represented as an adjacency list:
    /// each key is a vertex and its associated list contains that vertex's neighbours.
    /// </param>
    /// <param name="start">
    /// The vertex from which the traversal begins.
    /// </param>
    /// <returns>
    /// true if every vertex in <paramref name="graph"/> is reachable from
    /// <paramref name="start"/>; otherwise false.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the graph is non-empty and <paramref name="start"/> is not a vertex
    /// in the graph.
    /// </exception>
    /// <remarks>
    /// Assumes that <paramref name="graph"/> is a valid representation of an
    /// undirected graph:
    /// every neighbour appearing in an adjacency list is also a key in the graph,
    /// and if v lists w as a neighbour, then w lists v as a neighbour.
    /// The method does not modify the graph.
    /// </remarks>
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
            if (!visited.Add(v)) continue;

            foreach (string n in graph[v])
                work.Push(n);
        }

        return visited.Count == graph.Count;
    }


    public static HashSet<string> ReachableFrom(
        IReadOnlyDictionary<string, HashSet<string>> graph,
        string start)
    {
        //TODO
    }



    public static int CountComponents(
        IReadOnlyDictionary<string, HashSet<string>> graph)
    {
        //TODO
    }


    public static int ShortestDistance(
        IReadOnlyDictionary<string, HashSet<string>> graph,
        string start,
        string target)
    {
        //TODO
    }




}

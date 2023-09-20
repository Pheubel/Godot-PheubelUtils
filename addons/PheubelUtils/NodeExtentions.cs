#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Godot;

namespace PheubelUtils;

public static class NodeExtensions
{
    /// <summary>
    /// Itterates over the direct children of the node to find all nodes that match the given type.
    /// </summary>
    /// <typeparam name="T"> The type to be queried.</typeparam>
    /// <param name="parent"> The parent node whose direct children get scanned.</param>
    /// <returns> Array of direct children that match the given type.</returns>
    public static IReadOnlyList<T> GetChildrenOfType<T>(this Node parent) where T : class
    {
        List<T> matches = new();

        foreach (var childNode in parent.GetChildren())
        {
            if (childNode is T matchedNode)
                matches.Add(matchedNode);
        }

        return matches;
    }

    /// <summary>
    /// Itterates over the children of the node to find all nodes that match the given type.
    /// </summary>
    /// <typeparam name="T"> The type to be queried.</typeparam>
    /// <param name="parent"> The parent node whose direct children get scanned.</param>
    /// <param name="plungeChildren"> Determines if the full hierachy of children should be scanned, defaults to false.</param>
    /// <param name="matches"> The list in which the resulting matches will be stored into.</param>
    /// <returns> Array of direct children that match the given type.</returns>
    public static IReadOnlyList<T> GetChildrenOfTypeRecursive<T>(this Node parent) where T : class
    {
        List<T> matches = new();

        GetChildrenOfTypeRecursive(parent, matches);

        return matches;
    }

    private static void GetChildrenOfTypeRecursive<T>(Node parent, IList<T> matches) where T : class
    {
        foreach (var childNode in parent.GetChildren())
        {
            if (childNode is T matchedNode)
                matches.Add(matchedNode);

            GetChildrenOfTypeRecursive(parent, matches);
        }
    }

    /// <summary>
    /// Itterates over the direct children of the node to find the first node that match the given type.
    /// </summary>
    /// <typeparam name="T"> The type to be queried.</typeparam>
    /// <param name="parent"> The parent node whose direct children get scanned.</param>
    /// <returns> The first child that matches the given type or null if it is not found.</returns>
    public static T? GetChildOfTypeOrNull<T>(this Node parent, bool plungeChildren = false) where T : class
    {
        foreach (var childNode in parent.GetChildren())
        {
            if (childNode is T matchedNode)
                return matchedNode;
        }

        return null;
    }

    /// <summary>
    /// Itterates over the children of the node to find the first node that match the given type.
    /// </summary>
    /// <typeparam name="T"> The type to be queried.</typeparam>
    /// <param name="parent"> The parent node whose direct children get scanned.</param>
    /// <returns> The first child that matches the given type or null if it is not found.</returns>
    public static T? GetChildOfTypeOrNullRecursive<T>(this Node parent) where T : class
    {
        return TryGetChildOfTypeRecursive(parent, out T? node) ? node : null;
    }

    /// <summary>
    /// Itterates over the direct children of the node to find the first node that match the given type.
    /// </summary>
    /// <typeparam name="T"> The type to be queried.</typeparam>
    /// <param name="parent"> The parent node whose direct children get scanned.</param>
    /// <param name="node"> The first child that matches the given type or null if it is not found.</param>
    /// <returns> true if a node with the given type was found, false otherwise.</returns>
    public static bool TryGetChildOfType<T>(this Node parent, [NotNullWhen(true)] out T? node) where T : class
    {
        foreach (var childNode in parent.GetChildren())
        {
            if (childNode is T matchedNode)
            {
                node = matchedNode;
                return true;
            }
        }

        node = null;
        return false;
    }

    /// <summary>
    /// Itterates over the direct children of the node to find the first node that match the given type.
    /// </summary>
    /// <typeparam name="T"> The type to be queried.</typeparam>
    /// <param name="parent"> The parent node whose direct children get scanned.</param>
    /// <param name="node"> The first child that matches the given type or null if it is not found.</param>
    /// <returns> true if a node with the given type was found, false otherwise.</returns>
    public static bool TryGetChildOfTypeRecursive<T>(this Node parent, [NotNullWhen(true)] out T? node) where T : class
    {
        foreach (var childNode in parent.GetChildren())
        {
            if (childNode is T matchedNode)
            {
                node = matchedNode;
                return true;
            }

            if (TryGetChildOfTypeRecursive(childNode, out node))
                return true;
        }

        node = null;
        return false;
    }
}
using System.Collections.Generic;
using System;

public class Trie
{
    public readonly Node Root;

    public Trie()
    {
        this.Root = new Node(false);
    }

    public void Add(string sequence, int currentIndex = 0, Node currentNode = null)
    {
        if (currentNode == null)
            currentNode = this.Root;
        if (currentIndex == sequence.Length)
            return;

        var currentletter = sequence[currentIndex];
        if (!currentNode.Children.ContainsKey(currentletter))
        {
            bool isWord = currentIndex == sequence.Length - 1;
            currentNode.Children.Add(currentletter, new Node(isWord));
        }

        Add(sequence, currentIndex + 1, currentNode.Children[currentletter]);
    }

    public void Execute(string command, string sequence)
    {
        if (command == "add")
            this.Add(sequence);
        if (command == "find")
            this.FindCounts(sequence);
    }

    public void FindCounts(string stub)
    {
        var currentNode = this.FindNode(stub);
        if (currentNode == null)
        {
            Console.WriteLine(0);
        }
        else
        {
            var count = this.CountWords(currentNode);
            Console.WriteLine(count);
        }
    }

    public Node FindNode(string sequence, int currentIndex = 0, Node currentNode = null)
    {
        if (currentNode == null)
            currentNode = this.Root;

        if (currentIndex == sequence.Length)
            return currentNode;

        var currentletter = sequence[currentIndex];
        if (currentNode.Children.ContainsKey(currentletter))
        {
            return FindNode(sequence, currentIndex + 1, currentNode.Children[currentletter]);
        }

        return null;
    }

    public int CountWords(Node currentNode, List<Node> searched = null, int count = 0)
    {
        if (searched == null)
            searched = new List<Node>();
        if (!searched.Contains(currentNode))
        {
            if (currentNode.IsWord)
                count++;
            searched.Add(currentNode);
            foreach (var child in currentNode.Children.Values)
            {
                count = CountWords(child, searched, count);
            }
        }

        return count;
    }


}

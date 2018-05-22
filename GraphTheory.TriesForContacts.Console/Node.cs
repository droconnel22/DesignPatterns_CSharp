using System.Collections.Generic;

public class Node
{
    public bool IsWord;

    public Dictionary<char, Node> Children;

    public Node(bool IsWord)
    {
        this.IsWord = IsWord;
        this.Children = new Dictionary<char, Node>();
    }
}

using System;

namespace CodeWars.CodeWars.CSharp.DataStructures.BST
{
    public class Node<TKey> : INode<TKey>
        where TKey : IComparable<TKey>
    {
        public Node(TKey key)
        {
            if(key == null )
                throw new ArgumentNullException(nameof(key));
            this.key = key;
            this.count = 0;
        }

        public TKey key { get; }
        public int count { get; private set; }
       
        public INode<TKey> left { get; set; }
        public INode<TKey> right { get; set; }

        public void UpdateCount() => this.count++;
    }
}
namespace CodeWars.CodeWars.CSharp.DataStructures.BST
{
    public interface INode<TKey>
    {
        TKey key { get; }

        int count { get;}

        void UpdateCount();

        INode<TKey> left { get; set; }

        INode<TKey> right { get; set; }
    }
}

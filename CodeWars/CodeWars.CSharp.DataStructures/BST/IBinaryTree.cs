using System.Collections.Generic;

namespace CodeWars.CodeWars.CSharp.DataStructures.BST
{
    public interface IBinaryTree<TKey> 
    {
        void Put(TKey key);

        INode<TKey> Get(TKey key);

        void Delete(TKey key);

        INode<TKey> GetMinimum();

        TKey GetMaximum();

        TKey Floor(TKey key);

        TKey Ceiling(TKey key);

        int Size(TKey key);

        int Rank(TKey key);

        IEnumerable<TKey> InOrderTraversal();

        IEnumerable<TKey> PreOrderTraversal();

        IEnumerable<TKey> PostOrderTraversal();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CodeWars.CodeWars.CSharp.DataStructures.BST
{
    public class BinaryTree<TKey> : IBinaryTree<TKey>
        where TKey : IComparable<TKey>
    {

        private INode<TKey> rootNode;

        public BinaryTree(INode<TKey> node)
        {
            if(node == null)
                throw new ArgumentNullException(nameof(node));

            this.rootNode = node;
        }

        public void Put(TKey key)
        {
            INode<TKey> currentNode = this.rootNode;

            while (currentNode.key.CompareTo(key) != 0)
            {
                int comp = currentNode.key.CompareTo(key);
                if (comp < 0)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = new Node<TKey>(key);
                        currentNode.UpdateCount();

                    }

                    currentNode = currentNode.left;
                }

                if (comp > 0)
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = new Node<TKey>(key);
                        currentNode.UpdateCount();
                    }

                    currentNode = currentNode.right;

                }
            }
        }
        
        public INode<TKey> Get(TKey key)
        {

            INode<TKey> currentNode = this.rootNode;
            while (currentNode != null)
            {
                int comp = currentNode.key.CompareTo(key);
                if (comp < 0) currentNode = currentNode.left;
                if (comp > 0) currentNode = currentNode.right;
                if (comp == 0) return currentNode;
            }

            return null;
        }

        public void Delete(TKey key)
        {
            this.rootNode = HibbardDeletion(this.rootNode, key);
        }

        private INode<TKey> HibbardDeletion(INode<TKey> currentNode, TKey key)
        {
            //Case 0.
            if (currentNode == null) return null;
            int compare = key.CompareTo(currentNode.key);
            if (compare < 0) currentNode.left = HibbardDeletion(currentNode.left, key);
            else if (compare > 0) currentNode.right = HibbardDeletion(currentNode.right, key);
            else
            {
                //Case 1.
                if (currentNode.right == null)
                    return currentNode.left;

                //Case 2.
                var tempNode = currentNode;
                currentNode = currentNode; //min(tempNode.right);
                currentNode.right = null; //deleteMin(tempNode.right);
                currentNode.left = tempNode.left;
            }

            return currentNode;
        }

        //Traverse the right side only?
        public INode<TKey> GetMinimum()
        {
            INode<TKey> currentNode = this.rootNode;

            while (currentNode.right != null && currentNode.key.CompareTo(currentNode.right.key) > 0)
            {
                currentNode = currentNode.right;
            }

            return currentNode;
        }

        public TKey GetMaximum()
        {
            INode<TKey> currentNode = this.rootNode;

            while (currentNode.left != null && currentNode.key.CompareTo(currentNode.left.key) < 0)
            {
                currentNode = currentNode.left;
            }

            return currentNode.key;
        }

        public TKey Floor(TKey key)
        {
            throw new NotImplementedException();
        }

        public TKey Ceiling(TKey key)
        {
            throw new NotImplementedException();
        }

        public int Size(TKey key)
        {
            throw new NotImplementedException();
        }

        //How Many Keys less than K?
        public int Rank(TKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TKey> InOrderTraversal()
        {
            var keyList = new Queue<TKey>();
             inorder(this.rootNode, ref keyList);
            return keyList;
        }

        public IEnumerable<TKey> PreOrderTraversal()
        {
            var keyList = new Queue<TKey>();
            preorder(this.rootNode, ref keyList);
            return keyList;
        }

        private void preorder(INode<TKey> currentNode, ref Queue<TKey> keylist)
        {
            keylist.Enqueue(currentNode.key);
            preorder(currentNode.left,ref keylist);
            preorder(currentNode.right,ref keylist);
        }

        //Uses of Postorder
        // Postorder traversal is used to delete the tree.
        //http://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
        public IEnumerable<TKey> PostOrderTraversal()
        {
            var keyList = new Queue<TKey>();
            postorder(this.rootNode, ref keyList);
            return keyList;
        }

        public void postorder(INode<TKey> currentNode, ref Queue<TKey> keyList)
        {
            if (currentNode == null) return;
            postorder(currentNode.right, ref keyList);
            postorder(currentNode.left,ref keyList);
            keyList.Enqueue(currentNode.key);
        }


        //Goes through all the left, up up up. then returns in.
        //THen hits the node, and swings down to the right
        //down down down.
        private void inorder(INode<TKey> currentNode, ref Queue<TKey> keylist)
        {
            if (currentNode == null) return;
            inorder(currentNode.left, ref keylist);
            keylist.Enqueue(currentNode.key);
            inorder(currentNode.right, ref keylist);
        }
    }
}
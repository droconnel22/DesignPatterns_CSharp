using System;
using CodeWars.CodeWars.CSharp.DataStructures.BST;
using NUnit.Framework;

namespace CodeWars.CSharp.Tests.DataStructures
{

    [TestFixture]
    public class DataStructureTests
    {
        private IBinaryTree<int> intBinaryTree;

        private Random randomSeed = new Random(100);

        [SetUp]
        public void SetUp()
        {
            intBinaryTree = new BinaryTree<int>(new Node<int>(5));
            intBinaryTree.Put(3);
            intBinaryTree.Put(7);
            for (int i = 0; i < 100; i++)
            {
                intBinaryTree.Put(randomSeed.Next(0,100));
            }
        }


        [Test]
        public void BST_Tests()
        {
            
            var result = intBinaryTree.Get(3);
            Assert.IsNotNull(result);
            Assert.AreEqual(3,result.key);
        }

        [Test]
        public void BST_TREE_MIN_Tests()
        {
            var result = intBinaryTree.GetMinimum();

            Assert.IsNotNull(result);
        }

        [Test]
        public void BST_Find_Max_Tests()
        {
            var result = intBinaryTree.GetMaximum();
            Assert.IsNotNull(result);
        }

        [Test]
        public void BST_InOrder_Traversal()
        {
            var results = intBinaryTree.InOrderTraversal();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

    }
}

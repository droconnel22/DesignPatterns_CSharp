using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.CodeWars.CSharp.Arrays;
using NUnit.Framework;

namespace CodeWars.CSharp.Tests.SortingTests
{
    [TestFixture]
    public class MergeSortTests
    {
        [Test]
        public void MergeSort_WhengivenValidArray_AlwaysReturnsSorted()
        {
          var sentance = new char[] { 'e', 'e', 'g', 'm', 'r', 'a', 'c', 'e', 'r', 't' };

          var sortedSentance = MergeSort<char>.Merge(sentance);

         System.Console.WriteLine(sentance);
         System.Console.WriteLine(sortedSentance);
        }

        [Test]

        public void GenericMergeSort_WhenGivenTypeOfCharArray_AlwaysReturnsSorted()
        {

            var sentance = new char[] { 'd', 'e', 'n', 'n', 'i', 's', 'o', 'c', 'o', 'n', 'n', 'e', 'l', 'l' };

            var sortedSentance = MergeSort<char>.Merge(sentance);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler.CSharp.Tests
{
    [TestFixture]
    public class ProjectEulerTests
    {


        [Test]
        public void Problem_4_Largest_Palindrome()
        {
            int result = LargestPalindrome.Plaindrome();
            Console.WriteLine(result);
        }


        [Test]
        public void Problem_5_Smallest_Multiple()
        {
            int result = SmallestMultiple.Smallest();
            Console.WriteLine(result);
        }

        [Test]
        public void Problem_6_Sum_Of_Squares()
        {
            int result = SumOfSquares.SumSquares();
            Console.WriteLine(result);
        //Assert.AreEqual(2640,result);


    }

    }
}

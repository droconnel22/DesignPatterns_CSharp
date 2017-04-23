

using System.Collections;
using CodeWars.CodeWars.CSharp.Arrays;
using CodeWars.CodeWars.CSharp.Misc;

namespace CodeWars.CSharp.Tests
{

    using global::CodeWars.CodeWars.CSharp.AlgebraKata;
    using CodeWars.CSharp.Numbers;
    using global::CodeWars.CodeWars.CSharp.Strings;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class CsharpTests
    {
        [Test]
        public void CapitalizeFirstLetter_WhenGivenAnArray_ReturnsEachStringWithFirstLetterCapital()
        {
            var parser = new Captial_FirstLetter_StringArray();
            var Array1 =  new string[] { "jo", "nelson", "jurie" };
            var Array2 = new string[] { "KARLY", "DANIEL", "KELSEY" };

            var result = parser.CapMe(Array1);

            var result2 = parser.CapMe(Array2);

            foreach (var s in result)
            {
                Console.WriteLine(s);
            }

            foreach (var s in result2)
            {
                Console.WriteLine(s);
            }

            Assert.NotNull(result);
            Assert.NotNull(result2);
        }

        [Test]
        public void HighAndLow_WhenGivenStringOfNums_ReturnsStoredStringOfNums()
        {
              var highestAndLowest = new HighestandLowest();
         
              string numberArray = "-3 0 1 3 5 2";
              var result = highestAndLowest.HighAndLow(numberArray);
              var result1 = highestAndLowest.HighAndLow("1 2 3 4 5"); // return "5 1"
              var result2 =  highestAndLowest.HighAndLow( "1 2 -3 4 5"); // return "5 -3"
              var result3 =  highestAndLowest.HighAndLow( "1 9 3 4 -5"); // return "9 -5"
            
             Assert.NotNull(result);
             Console.WriteLine(result);
             Assert.AreEqual(result1, "5 1");
             Console.WriteLine(result1);
             Assert.AreEqual(result2, "5 -3");
             Console.WriteLine(result2);
             Assert.AreEqual(result3, "9 -5");
             Console.WriteLine(result3);
        }

        [Test]
        public void HighAndLowAlternative()
        {
            var highestAndLowest = new HighestandLowest();
            
            var result1 = highestAndLowest.HighAndLowAlternative("1 2 3 4 5"); // return "5 1"
            var result2 = highestAndLowest.HighAndLowAlternative("1 2 -3 4 5"); // return "5 -3"
            var result3 = highestAndLowest.HighAndLowAlternative("1 9 3 4 -5"); // return "9 -5"

            Assert.AreEqual(result1, "5 1");
            Console.WriteLine(result1);
            Assert.AreEqual(result2, "5 -3");
            Console.WriteLine(result2);
            Assert.AreEqual(result3, "9 -5");
            Console.WriteLine(result3);
        }

        [Test]
        public void CaptialsToIndexesTest()
        {

            var capitals = new CaptialsToIndexes();
            var result = capitals.CountCaptials("CodEWaRs");

            Assert.AreEqual(result, new int[] { 0, 3, 4, 6 });
        }


        [Test]
        public void CandyProblemTests()
        {
            int[] candies = { 5, 8, 6, 4 };

            int[] candytest2 = { 1, 2, 4, 6 };

            int[] candyTest3 = { 1, 2 };

            int[] candyTest4 = { 4, 2 };

            int result = CandyProblem.GetMissingCandies(candies);
            int result2 = CandyProblem.GetMissingCandies(candytest2);
            int result3 = CandyProblem.GetMissingCandies(candyTest3);
            int result4 = CandyProblem.GetMissingCandies(candyTest4);

            Assert.AreEqual(9, result);
            Assert.AreEqual(11,result2);
            Assert.AreEqual(1, result3);
            Assert.AreEqual(2, result4);

        }

        [Test]
        public void CompleteThePatternTests()
        {
            Console.WriteLine(CompleteThePattern.Pattern(1));
            Console.WriteLine(CompleteThePattern.Pattern(2));
            Console.WriteLine(CompleteThePattern.Pattern(0));
            Console.WriteLine(CompleteThePattern.Pattern(5));

            Assert.AreEqual("1", CompleteThePattern.Pattern(1));
            Assert.AreEqual("21\n2", CompleteThePattern.Pattern(2));
            Assert.AreEqual("54321\n5432\n543\n54\n5", CompleteThePattern.Pattern(5));
        }


        [Test]
        public void ShouldFailNegativeNumber()
        {
            Assert.Throws<ArgumentException>(delegate { CalculateAreaOfCircle.AreaOfCircle("-123"); });
            //Assert.Throws(typeof(ArgumentException), Kata.CalculateAreaOfCircle("-123"));
        }

        [Test]
        public void ShouldFailAlphaNumeric()
        {
            Assert.Throws<ArgumentException>(delegate { CalculateAreaOfCircle.AreaOfCircle("number"); });
        }

        [Test]
        public void ShouldPass1()
        {
            Assert.AreEqual(5881.25, CalculateAreaOfCircle.AreaOfCircle("43.2673"));
        }


        [Test]
        public void GivenTwoNumbers_WhenResolvedThroughGivenEquation_AlwaysReturnsACountOfIntegerPairs()
        {
              Assert.AreEqual(-1, Algebra.Function_A(0,1001));

              Assert.AreEqual(1, Algebra.Function_A(9,3));

              Assert.AreEqual(1, Algebra.Function_A(14, 28));

              Assert.AreEqual(0, Algebra.Function_A(4, 20));

        }

        [Test]
        public void ValidateUserName_UsingRegex_AlwaysPassesGivenRequirements()
        {
            var classUnderTest = new ValidateUserName_UsingRegex();

            Assert.IsTrue(classUnderTest.ValidateUserName("asddsa"));
            Assert.IsFalse(classUnderTest.ValidateUserName("a"));
            Assert.IsFalse(classUnderTest.ValidateUserName("Hass"));
            Assert.IsFalse(classUnderTest.ValidateUserName("Hasd_12ssssssssssssssasasasasasssasassss"));
            Assert.IsFalse(classUnderTest.ValidateUserName(""));
            Assert.IsTrue(classUnderTest.ValidateUserName("____"));
            Assert.IsFalse(classUnderTest.ValidateUserName("012"));
            Assert.IsTrue(classUnderTest.ValidateUserName("p1pp1"));
            Assert.IsFalse(classUnderTest.ValidateUserName("asd43 34"));
            Assert.IsTrue(classUnderTest.ValidateUserName("asd43_34"));
        }

        [Test]
        public void WhenRunningFibonacciSequence_AlwaysReturnCountOfUniqueOddNumbers()
        {

        }

        [Test]
        public void IntCubeSumDiv()
        {
            var watermelon = new WatermelonProblem();

            var result = watermelon.IntCubeSumDiv(1);
            Assert.AreEqual(6, result);
            Assert.AreEqual(28, watermelon.IntCubeSumDiv(2));
            Assert.AreEqual(30, watermelon.IntCubeSumDiv(3));
            Assert.AreEqual(84, watermelon.IntCubeSumDiv(4));
            Assert.AreEqual(102, watermelon.IntCubeSumDiv(5));
        }

        [Test]
        public void SumSeasonScoresTest()
        {
            int result = SumSeasonScore.SumScore("10,5,0,8,10,1,4,0,10,1");
            Console.WriteLine(result);
        }


        [Test]
        public void PalindromeChallangeTestDome()
        {
            string example = "Noel sees Leon.";

            bool result = PlaindromeChallenge.IsPalindrome(example);

            Assert.IsTrue(result);
        }


        /* Frog */

         [Test]
        public void FrogGoesTheDistance()
        {
            //int total = 3;
             int total = 5;

            int ways = Frog.NumberOfWays(total);

            Assert.AreEqual(7,ways);
        }

        [Test]
        public void TestInserationSort()
        {
            int[] array = new[] {3, 7, 4, 1, 9, 11, 43, 32, 12};

            var result = InserationSort.Sort(array);
            result.ToList().ForEach(Console.Write);
        }

        [Test]
        public void LeetSpeak()
        {
            Assert.AreEqual("1337", LeetSepak.ToLeetSpeak("LEET"));
            Assert.AreEqual("(0D3W@R$", LeetSepak.ToLeetSpeak("CODEWARS"));
            Assert.AreEqual("#3110 W0R1D", LeetSepak.ToLeetSpeak("HELLO WORLD"));
            Assert.AreEqual("10R3M !P$UM D010R $!7 @M37", LeetSepak.ToLeetSpeak("LOREM IPSUM DOLOR SIT AMET"));
            Assert.AreEqual("7#3 QU!(K 8R0WN F0X JUMP$ 0V3R 7#3 1@2Y D06", LeetSepak.ToLeetSpeak("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG"));
        }


        [Test]
        public void PatterCraft_Decorator()
        {
            var marine = new Marine(10,1);
            
            Assert.AreEqual(11,new MarineWeaponUpgrade(marine).Damage);
            Assert.AreEqual(11, new MarineWeaponUpgrade(marine).Damage);
        }

        [Test]
        public void _1_DoubleUpgrade()
        {
            IMarine marine = new Marine(15, 1);
            marine = new MarineWeaponUpgrade(marine);
            marine = new MarineWeaponUpgrade(marine);

            Assert.AreEqual(17, marine.Damage);
        }

        [Test]
        public void _2_TripleUpgrade()
        {
            IMarine marine = new Marine(20, 1);
            marine = new MarineWeaponUpgrade(marine);
            marine = new MarineWeaponUpgrade(marine);
            marine = new MarineWeaponUpgrade(marine);

            Assert.AreEqual(23, marine.Damage);
        }

        [Test]
        public void Help_Your_Granny_Tour()
        {
            string[] friends1 = new string[] { "A1", "A2", "A3", "A4", "A5" };
            string[][] fTowns1 = { new string[] { "A1", "X1" }, new string[] { "A2", "X2" }, new string[] { "A3", "X3" }, new string[] { "A4", "X4" } };
            Hashtable distTable1 = new Hashtable { { "X1", 100.0 }, { "X2", 200.0 }, { "X3", 250.0 }, { "X4", 300.0 } };
           // Assert.AreEqual(889, HelpYourGranny.tour(friends1, fTowns1, distTable1));
        }

        [Test]
        public void ShiftedArray()
        {
           // var arrayOfArrays = new int[][] { new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 7, 7, 7, 7, 7, -7 } };
           // var expected = new int[] { 8, 9, 10, 11, 12, -1 };
           //  result = Shifted_Array.AddingShifted(arrayOfArrays, 0);
            //Assert.IsNotNull(result);
            //Assert.AreEqual(string.Join(",", expected), string.Join(",", result));

            var arrayOfArrays = new int[][] { new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 7, 7, 7, 7, 7, 7 } };
            var  expected = new int[] { 1, 2, 3, 11, 12, 13, 7, 7, 7 };
            var result = Shifted_Array.AddingShifted(arrayOfArrays, 3);
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Join(",", expected), string.Join(",", result));

            arrayOfArrays = new int[][] { new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 7, 7, 7, -7, 7, 7 }, new int[] { 1, 1, 1, 1, 1, 1 } };
            expected = new int[] { 1, 2, 3, 11, 12, 13, -6, 8, 8, 1, 1, 1 };
            result = Shifted_Array.AddingShifted(arrayOfArrays, 3);
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Join(",", expected), string.Join(",", result));
        }

        [Test]
        public void PrimeFibonacci_From50()
        {

            //PrimeFibonacci.Main();
            CorconFibonacci.Main();
            //int n = 50;

            //IEnumerable<long> basicResultArray = PrimeFibonacci.BasicFibonacci(50);
            //foreach (var l in basicResultArray)
            //{
            //    Console.WriteLine(l);
            //}

            //Console.WriteLine("\n--------\n");
            //IEnumerable<long> resultArray = 
            //    PrimeFibonacci
            //    .Calculate(50)
            //    .Where(PrimeFibonacci.IsPrime);

            //foreach (var l in resultArray)
            //{
            //    Console.WriteLine(l);
            //}
        }


        [Test]
        public void AppendAndDeleteTest()
        {
            Assert.AreEqual("No",AppendAndDelete.Main("y","yu",2));
            Assert.AreEqual("No", AppendAndDelete.Main("abcd", "abcdert", 10));
            Assert.AreEqual("No", AppendAndDelete.Main("hackerhappy", "hackerrank", 9));
            Assert.AreEqual("Yes", AppendAndDelete.Main("aba", "aba", 7));
        }


        [Test]
        public void LibraryFineTests()
        {
            /*
                6 6 2015
                9 6 2016
                0
            */
            /*

              31 8 2004
              20 1 2004
              3500
           */

            //returned, expected
            Assert.AreEqual(0, LibraryFine.Fine("6", "6", "2015", "2016", "6", "9"));
            Assert.AreEqual(3500, LibraryFine.Fine("31", "8", "2004", "2004", "1", "20"));
            Assert.AreEqual(0, LibraryFine.Fine("7", "2", "1014", "1015", "1", "1"));

        }

        [Test]
        public void Help_Your_Granny_Tour_2()
        {
            string[] friends1 = new string[] { "B1", "B2"};
            string[][] fTowns1 = { new string[] { "B1", "Y1" }, new string[] { "B2", "Y2" }, new string[] { "B3", "Y3" }, new string[] { "B4", "Y4" } };
            Hashtable distTable1 = new Hashtable { { "Y1", 50.0 }, { "Y2", 70.0 }, { "Y4", 110.0 }, { "Y5", 150.0 } };
           // Assert.AreEqual(168, HelpYourGranny.tour(friends1, fTowns1, distTable1));
        }


       
            [Test]
            public void CoinChallengeTests()
            {
                Assert.AreEqual(4, CoinChallenge.MakeChange(new[] { 1, 2, 3 }, 4));
            }
    }

}

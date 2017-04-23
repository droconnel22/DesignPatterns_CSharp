using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Misc
{
    //https://www.toptal.com/c-sharp/interview-questions
    public static class InterviewChallenges
    {
        // does the candidate consider linq, versus long line solution
        // does the candidate consider overflow

        public static long SumIntArray()
        {

            int[] intArray = new[] {4, 3, 6, 3, 5, 2, 9, 0, 1};
            long sum = 0;

            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i]%2 == 0)
                {
                    sum +=  (long)intArray[i];
                }
            }

            return sum;

            return intArray.Where(x => x%2 == 0).Sum(y => (long)y);
        }


        //Legal to compare an non instatned reference type and reference type null;

        static DateTime time;

        public static void IsNullTime()
        {
            if (time == null)
            {
                /* */
            }
        }

    }

    //Write code to calculate the circumferernce of the circle, without modifying the Circle Class itself.

    public sealed class Circle
    {
        private double radius;

        //takes in a double and returns a double (functor)
        public double Calculate(Func<double, double> op)
        {
            return op(radius);
        }
    }

    public static class Circumference
    {
        public static double GetCircumference(double radius)
        {
            return 2*Math.PI* radius;
        }
    }


    public static class CirlceMain
    {
        // By tuple

        public static double Main()
        {
            var circle = new Circle();
            
            double result =  circle.Calculate(Circumference.GetCircumference);
            return result;
        }

        // By Linq, which is more direct tuple.

        public static double Main_Answer()
        {
            var circle = new Circle();

            return circle.Calculate(x => 2*Math.PI*x);
        }
    }


    public  class AsyncOutput
    {
        private static string result;


        // Becuase this method is not awaited, the execution of this current method continues before it's completed.
        static void Main()
        {
            SaySomething();
            Console.WriteLine(result);
        }

        // An async method without at least one await statement in it operates just like a synchronous method
        private static async Task<string> SaySomething()
        {
            await Task.Delay(5);
            result = "Hello World!";
            return "Something";
        }
    }

    public class PrinterOutput
    {
        delegate void Printer();

        static void Main()
        {
            List<Printer> printers = new List<Printer>();
            for (int i = 0; i < 10; i++)
            {
                printers.Add(delegate { Console.WriteLine(i); });
            }

            foreach (var printer in printers)
            {
                printer();
            }
        }
    }


    // My guess: 
    /* 
    the deleage declared at the top matters for add method, which defineds the reference type that is required
    upon add call the appriopirate method is called. 

    But what smells is I, what stores it??
    i is garbage collected and cw is immediately envoked... At least I am assuming that.

    output is 0-9 then error

    =========result =======

    This program will output the number 10 ten times. I is last assigned 10, then not yet garbage collected....

    Here’s why: The delegate is added in the for loop and “reference” (or perhaps “pointer” would be a better choice of words)
    to i is stored, rather than the value itself. Therefore, after we exit the loop, the variable i has been set to 10, so by 
    the time each delegate is invoked, the value passed to all of them is 10.

    */

    /* There is more to interviewing than tricky technical questions, so these are intended merely as a guide.
    Not every “A” candidate worth hiring will be able to answer them all, nor does answering them all guarantee an “A” candidate. 
    At the end of the day, hiring remains an art, a science — and a lot of work. */


    /*
    ****
        
    Write a function that checks if a given sentence is a palindrome. A palindrome is a word, phrase, verse, 
    or sentence that reads the same backward or forward. Only the order of English alphabet letters (A-Z and a-z)
    should be considered, other characters should be ignored.

    For example, IsPalindrome("Noel sees Leon.") should return true as spaces, period, and case should be 
    ignored resulting with "noelseesleon" which is a palindrome since it reads same backward and forward.
    */

public static class PlaindromeChallenge
{
        public static bool IsPalindrome(string str)
        {
            bool result = true;
            char[] validArray = str.Select(char.ToLower).Where(char.IsLetter).ToArray();

            for (int i = 0; i < validArray.Length / 2; i++)
            {
                if (validArray[i] != validArray[validArray.Length - 1 - i])
                {
                    result = false;
                    break;
                }
           }

            return result;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome("Noel sees Leon."));
        }
}


    /*

    Frog

    A frog only moves forward, but it can move in steps 1 inch long or in jumps 2 inches long. 

    A frog can cover the same distance using different combinations of steps and jumps.

    Write a function that calculates the number of different combinations a frog can use to cover a given distance.

    For example, a distance of 3 inches can be covered in three ways: step-step-step, step-jump, and jump-step.
    https://www.testdome.com/Questions/Csharp/Frog/4948?testId=21&testDifficulty=Easy
    */

    public static class Frog
    {
        private static readonly int jump = 2;
        private static readonly int step = 1;


        public static int NumberOfWays(int n)
        {
            int wayCount = 0; //all 1's always can matteer
            if (n <= 0)
            {
                return 0;
            }

            Increment(ref wayCount,0, 1, n);
            return wayCount;
        }


        public static void Increment(ref int wayCount, int distanceCovered, int incrementValue, int totalDistance)
        {
            int distanceToGo = totalDistance - distanceCovered;

            if (distanceToGo == 0)
            {
                wayCount++;
                return;
            }

            if (distanceToGo >= jump)
            {
                Increment(ref wayCount, distanceCovered + jump, jump, totalDistance);
            }

            if (distanceToGo >= step)
            {
                Increment(ref wayCount, distanceCovered + step, step, totalDistance);
            }
            
        }

        public static void Main(String[] args)
        {
            Console.WriteLine(NumberOfWays(3));
        }
    }

}

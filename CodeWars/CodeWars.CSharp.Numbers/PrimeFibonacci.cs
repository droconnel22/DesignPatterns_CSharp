using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

//Code wars is my solution for daily exercises and training.
namespace CodeWars.CodeWars.CSharp.Numbers
{
    /// <summary>
    /// Write a program in C# that prints the first 50 numbers in the 
    /// Fibonacci sequence starting with 0, then print them out again 
    /// in descending order but remove all of the prime numbers.
    /// </summary>

    /// PLEASE READ NOTES ON BOTTOM - Thank you to Corcoran Group!

    public static class PrimeFibonacci
    {

        private  static IEnumerable<long> BasicFibonacci(int N)
        {
            int currentIndex = 0;
            var resultArray = new long[N];

            long previousNumber = 0;
            long nextNumber = 1;

            while (currentIndex != N)
            {
                long temp = previousNumber;
                previousNumber = nextNumber;
                nextNumber += temp;
                resultArray[currentIndex] = previousNumber;
                currentIndex++;
            }

            return resultArray;
        }

        private static Stack<long> resultStack;
        
        private  static IEnumerable<long> Calculate(int N)
        {
            int currentIndex = 0;
            resultStack = new Stack<long>(50);

            long previousNumber = 0;
            long nextNumber = 1;

            while (currentIndex != N)
            {
                long temp = previousNumber;
                previousNumber = nextNumber;
                nextNumber += temp;

                resultStack.Push(previousNumber);
                currentIndex++;
            }

            return resultStack;
        }


        private  static bool IsPrime(long number)
        {
           //guard clauses
            if (number <= 1) return false;
            if (number%2 == 0) return number == 2;

            long squareRoot = (long) (Math.Sqrt(number) + 0.5);
            for (int j = 3; j <= squareRoot; j += 2)
            {
                if (number%j == 0) return false;
            }

            return true;
        }


        public static void Main()
        {
            int n = 50;
            IEnumerable<long> basicResultArray = PrimeFibonacci.BasicFibonacci(50);
            foreach (var l in basicResultArray)
            {
                Console.WriteLine(l);
            }

            Console.WriteLine("\n--------\n");

            IEnumerable<long> resultArray =
                PrimeFibonacci
                .Calculate(50)
                .Where(IsPrime);

            foreach (var l in resultArray)
            {
                Console.WriteLine(l);
            }


            var result = 
                BasicFibonacci(50)
                .Where(IsPrime)
                .OrderByDescending(p => p);


        }
    }

    /*
    Thank you to the Corcoran Group for consideration.

    I went to put my thought process down here.

    First, the trap is going Recursive because it puts the algo at risk of a stack over flow error and memory leak error.

    I am choosing an int64 because the growth rate must be considered. ( I can technically go uint64, but that might be too low level)

    My data structure of choice is IEnumerable<long> because I do not need the API from ICollection and IList, which shares the same library
        
    -----

    OrderbyDescending from the System.Linq library is stable sort (meaning duplicates are preserved) and runs a quick sort alogarithm.

    Quick sort is O(N log(N)) performance in the average case BUT in the worst case (fully reverse sorting an array already in order) is O(n^2)

    Given this reality perhaps not a simple IEnumerable but a Stack data structure is most appropriate since order by descending will be such a cost and 
    
    we will need first in, last out naturally. Stack also naturally grows with the collection unlike the array. 

    We can use covariance for the return type, since the Stack Data Structure class inherits from the interface IEnumerable<T>.

    Upon test we can initialize a Stack<long> data structure with N, and it naturally gives us an order by descending print out.

    -----

    Now I am thinking about the IsPrime Method. I separated that to a different method and in a production I would re factor it out to separate strategy 
    
    class that would consumed by the Prime Fibonacci class (single responsibility, separation of concerns, and open/close principal).


    ------

     Ok I just re-read the directions and noticed that there are two prints. Which mean I can use an OrderByDescnding and Where Clause for a single call 
    
    for the BasicFibonacci method, but I want to show depth, so if it's ok I will keep the seperate method which 
    
    has more interesting data structures and is more performant then a worst case reverse sort of a quick sort result.
    
    I want to reiterate you can leverage code re-use with the Basic Fibonacci call by using .OrderByDescending() and
    
    a .Where with a functor passed (c# Action or delegate). 
    
    
    ---
    
    I will keep to separate methods in the hope it showcases my depth and passion as well my concern about best performance
    
    and code readability.

   

    */
        // Thank yo uto the Corcoran Group for consideration.
        public static class CorconFibonacci
        {

            /// Write a program in C# that prints the first 50 numbers in the 
            /// Fibonacci sequence starting with 0, then print them out again 
            /// in descending order but remove all of the prime numbers.

            // Run Here.
            public static void Main()
            {
                //Print first 50 Numbers (N) in the Fibonacci Sequence
                IEnumerable<long> basicResultArray = CalculateFibonacci(50);
                PrintResult(basicResultArray);

                Console.WriteLine("\n----------\n");

                //Print them out again in descending order but remove all prime numbers.
                var reversedPrimeFibonacci =
                                        basicResultArray
                                        .Where(p => IsPrime(p) == false)
                                        .OrderByDescending(p => p);
                PrintResult(reversedPrimeFibonacci);
            }


            private static void PrintResult(IEnumerable<long> array)
            {
                foreach (var l in array)
                {
                    Console.WriteLine(l);
                }
            }

            private static IEnumerable<long> CalculateFibonacci(int N)
            {
                int currentIndex = 0;
                //known collection size can use Array.
                var resultArray = new long[N];

                long previousNumber = 0;
                long nextNumber = 1;

                while (currentIndex != N)
                {
                    long temp = previousNumber;
                    previousNumber = nextNumber;
                    nextNumber += temp;
                    resultArray[currentIndex] = previousNumber;
                    currentIndex++;
                }

                return resultArray;
            }
            
            private static bool IsPrime(long number)
            {
                //guard clauses
                if (number <= 1) return false;
                if (number % 2 == 0) return number == 2;
                
                long squareRoot = (long)(Math.Sqrt(number));
                for (int i = 3; i <= squareRoot; i += 2)
                {
                    if (number % i == 0) return false;
                }

                return true;
            }
        }
}

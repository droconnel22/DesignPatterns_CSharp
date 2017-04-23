using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.ManagingResponsibilities.MapReducePattern
{
    class Program
    {

        static int CalculateControlDigit(long number)
        {
            //Partition Data or obtain
            IEnumerable<int> digits = GetDigitsFromLeastSignificant(number);

            //Apply Mapping
            IEnumerable<int> factors = GetMultiplicativeFactors();
            IEnumerable<int> weightedDigits = AddWeight(digits, factors);

            //Reduce
            int sum = Sum(weightedDigits);

            int result = sum % 11;
            if (result == 10)
                result = 1;
            return result;
        }

        private static int Sum(IEnumerable<int> weightedDigits)
        {
            int sum = 0;

            foreach (var weightedDigit in weightedDigits)
            {
                sum += weightedDigit;
            }

            return sum;
        }

        private static IEnumerable<int> AddWeight(IEnumerable<int> values, IEnumerable<int> factors)
        {
            IEnumerator<int> factor = factors.GetEnumerator();
            List<int> weightedValues = new List<int>();

            foreach (int digit in values)
            {
                factor.MoveNext();
                weightedValues.Add(factor.Current*digit);
            }

            return weightedValues;
        }

        private static IEnumerable<int> GetMultiplicativeFactors()
        {
            return new int[] {1,3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3};
        }

        private static IEnumerable<int> GetDigitsFromLeastSignificant(long number)
        {
            do
            {
                //wont take up memory, just hold the lateset in mind.
                yield return (int)(number % 10);
                number /= 10;

            } while (number > 0);

        }

        static int CalculateControlDigitLINQ(long number)
        {
            //Partition Data or obtain
            int sum = 
                number
               .GetDigitsFromLeastSignificantLINQ()
               .AddWeights(MultiplicativeFactors)
               .Sum();
            

            int result = sum % 11;
            if (result == 10)
                result = 1;
            return result;
        }

    

        static void Main(string[] args)
        {
            Console.WriteLine("{0}", CalculateControlDigit(82712476));
            Console.ReadLine();
        }

        static  IEnumerable<int> MultiplicativeFactors
        {
            get
            {
                while (true)
                {
                    yield return 1;
                    yield return 3;
                }
            }
        }
    }

   static class Int64Extensions
    {
      public  static IEnumerable<int> GetDigitsFromLeastSignificantLINQ(this long number)
        {
            List<int> digits = new List<int>();
            do
            {
                int digit = (int)(number % 10);
                digits.Add(digit);
                number /= 10;

            } while (number > 0);

            
            return digits;
        }
    }


    static class IntSequenceUtils
    {
        public static IEnumerable<int> AddWeights(this IEnumerable<int> values, IEnumerable<int> factors)=> values.Zip(factors, (v, f) => v*f);
    }
}

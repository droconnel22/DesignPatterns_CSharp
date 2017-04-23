using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.CSharp
{
    public static class SmallestMultiple
    {
        /// <summary>
        /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        /// </summary>
        /// <returns></returns>

        public static int Smallest()
        {
            int number = 20;
            int divisor = 20;
            while (divisor > 0)
            {
                if (number % divisor == 0)
                {
                    divisor--;
                }
                else
                {
                    number++;
                    divisor = 20;
                }
            }


            return number;
        }
    }
}

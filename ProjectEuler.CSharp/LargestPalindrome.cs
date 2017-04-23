using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.CSharp
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers
    ///  is 9009 = 91 × 99.
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    public static class LargestPalindrome
    {
        public static int Plaindrome()
        {
            int firstNum = 999, secondNum = 999;
            var productArray = (firstNum * secondNum).ToString();
            int index = 0;
            while (index < productArray.Length /2)
            {
                if (productArray[index] != productArray[productArray.Length - 1 - index])
                {
                    secondNum--;
                    if (secondNum < 900)
                    {
                        firstNum--;
                        secondNum = 999;
                    }

                    productArray = (firstNum*secondNum).ToString();
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            return firstNum * secondNum;
        }
    }
}

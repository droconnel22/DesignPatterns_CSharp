using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.CSharp
{
    public static class SumOfSquares
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public static int SumSquares()
        {
            int sum = 0;
            int sumOfSquares = 0;
            for (int i = 1; i < 101; i++)
            {
                sum += i;
                sumOfSquares += (i*i);
            }

            return  (sum*sum) - sumOfSquares;

        }
    }
}

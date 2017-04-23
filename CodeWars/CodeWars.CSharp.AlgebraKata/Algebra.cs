namespace CodeWars.CodeWars.CSharp.AlgebraKata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /*asya isn't really good at math. However, he wants to get a good mark for the class. So he made a deal with his teacher. "I wil study very hard and will be able to solve any given problem!" - Vasya said.

        Finally, today is the time to show what Vasya achieved. He solved the given task immediately. Can you?

        Task:

        You are given a system of equations:



        In JS, C# and Java the parameters of the system: 1 ≤ n, m ≤ 1000

        You should count, how many there are pairs of integers (a, b) (0 ≤ a, b) which satisfy the system.

        Examples

        SystemOfEq.Solution(9,3) // => 1 
        SystemOfEq.Solution(14,28) // => 1
        SystemOfEq.Solution(4,20) // => 0
     * 
     */


    public static class Algebra
    {

        private const int m_upper_bound = 1000;

        private const int n_lower_bound = 1;

        public static void Program(int n, int m)
        {          
           

            while (m <= m_upper_bound && n >= n_lower_bound)
            {               
                m++;
                n++;
            }

          
            
        }

        // Given a singular pair.
        public static int Function_A(int n, int m)
        {

            if(n < n_lower_bound && m > m_upper_bound) 
            {
                return -1;
            }

            int integer_count = 0;
           

            for (int a = 0; a < 1000; a++ )
            {
                for(int b = 0; b < 1000; b++)
                {
                    if (n == Function_N(a, b) && m == Function_M(a, b))
                    {
                        integer_count++;
                    }
                }
            }

            return integer_count;
        }

        private static double Function_N(int a, int b)
        {
            return Math.Pow(a, 2) + b;
        }

        private static double Function_M(int a, int b)
        {
            return Math.Pow(b, 2) + a;
        }


        private static int Solution(int n, int m)
        {
            throw new NotImplementedException();
        }
    }
}

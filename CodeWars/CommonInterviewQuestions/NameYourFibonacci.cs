using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CommonInterviewQuestions
{

    //Write a function to calculate the nth number in the Fibonacci sequence.

    public sealed class NameYourFibonacci
    {
        public static int WhatFibonaicc(int nNumber)
        {
            // 0 1 1 2 3 5 8 13
            if (nNumber == 1) return 0;
            if (nNumber <= 3) return 1;

            int counter = 3;
            int previous = 1;
            int result = 1;
            while(counter != nNumber)
            {
                previous = result;
                result = previous + result;
                counter++;
            }

            return result;
        }
    }
}

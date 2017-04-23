using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Numbers
{
    public static class CalculateAreaOfCircle
    {

        //Kata.CalculateAreaOfCircle("-123"); //throws ArgumentException
        //Kata.CalculateAreaOfCircle("0"); //throws ArgumentException
        //Kata.CalculateAreaOfCircle("43.2673"); //return 5881.25
        //Kata.CalculateAreaOfCircle("68"); //return 14526.72
        //Kata.CalculateAreaOfCircle("number"); //throws ArgumentException
        

        public static double AreaOfCircle(string radius)
        {
            double result;
            if (radius.Contains(","))
            {
                throw new ArgumentException();
            }

            if (!double.TryParse(radius, out result) || result <= 0)
            {
                throw new ArgumentException();
            }

            return Math.Round(Math.Pow(result,2) * Math.PI,2);
        }
    }
}

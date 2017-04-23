using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Misc
{
    public static class LibraryFine
    {

        public static int Fine(string d1, string m1, string y1, string y2, string m2, string d2)
        {

            int HackosCost = 0;
            var date_returned = DateTime.Parse(y1 + "-" + m1 + "-" + d1);
            var date_expected = DateTime.Parse(y2 + "-" + m2 + "-" + d2);

            TimeSpan ts = date_returned - date_expected;

            if (date_returned.Year <= date_expected.Year)
            {
                if (date_returned.Month <= date_expected.Month)
                {
                    if (ts.TotalDays < 0)
                    {
                        HackosCost = 0;
                    }
                    else
                    {
                        HackosCost = Math.Abs(Convert.ToInt32(d1)- Convert.ToInt32(d2))*15;
                    }
                }
                else
                {

                    if (ts.TotalDays < 0)
                    {
                        HackosCost = 0;
                    }
                    else
                    {
                        HackosCost = 500 * Math.Abs(Convert.ToInt32(m1) - Convert.ToInt32(m2));
                    }
                  
                }
            }
            else 
            {
                HackosCost = 10000;
            }

            return HackosCost;
        }
    }
}

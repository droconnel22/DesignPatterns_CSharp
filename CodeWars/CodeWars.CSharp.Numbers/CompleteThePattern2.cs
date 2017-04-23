using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Numbers
{
   public static class CompleteThePattern2
    {
        public static string Pattern(int n)
        {
            string result = string.Empty;
             if(n <= 0)
             {
                 return string.Empty;
             }

            for (int i = 0; i < n; i++)
            {
                result += i.ToString();
            }

            return result;

        }
    }
}

using System;

namespace CodeWars.CodeWars.CSharp.Numbers
{

   // You have to write a function pattern which creates the following 
   // pattern upto n number of rows. If the Argument is 0 or 
   // a Negative Integer then it should return "" i.e. empty string.

   public static class CompleteThePattern
    {
       public static string Pattern(int number)
       {
           if (number < 0 || number == 0)
           {
               return string.Empty;
           }

           int upperboundary = number;
           int lowerboundary = 0;
           string result = string.Empty;

           while (lowerboundary != upperboundary)
           {
               for (int i = upperboundary; i > lowerboundary; i--)
               {
                  result += i.ToString();
               }

               lowerboundary++;
               if (lowerboundary != upperboundary)
               {
                   result += "\n";  
               }
           }
           return result;
       }
    }
}

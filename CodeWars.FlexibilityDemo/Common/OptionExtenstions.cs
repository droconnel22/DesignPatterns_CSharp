using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.FlexibilityDemo.Common
{
    /// <summary>
    /// Beware of accidental introduction of costly operations
    /// 
    /// this toList() call requires O(n) memory!
    /// 
    /// sequence itslef might require O(1) only.
    /// </summary>

   static  class OptionExtenstions
    {
       public static void Do<T>(this IEnumerable<T> sequence, Action<T> action)
       {
            //sequence.ToList().ForEach(action);
            //Optimize to avoid to list()
           foreach (T obj in sequence)
               action(obj);

       }
    }
}

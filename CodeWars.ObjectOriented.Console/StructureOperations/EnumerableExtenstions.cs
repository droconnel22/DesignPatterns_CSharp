using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.StructureOperations
{
    public static class EnumerableExtenstions
    {
        //inside () is method signature
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
                sequence.Aggregate((T)null, (best, cur) =>
                   best == null || criterion(cur).CompareTo(criterion(best)) < 0 ? cur : best);
        // So basically this guys argurment is that exentions methods are infrastructure code with remains out of site 
        // and that this allows implementation code to remain clean. (which this is total bs)

        public static T WithMiniumFast<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
                sequence
                    .Select(obj => Tuple.Create(obj, criterion(obj)))
                    .Aggregate((Tuple<T, TKey>)null,
                        (best, current) => best == null || current.Item2.CompareTo(best.Item2) < 0 ? current : best)
                    .Item1;
    }
}

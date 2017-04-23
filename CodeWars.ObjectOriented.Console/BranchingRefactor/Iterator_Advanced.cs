using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.ObjectOriented.Console.BranchingRefactor
{
    interface IPainter
    {
        bool IsAvailble { get;}
        double EstimateCompenstation(double sqMeters);
        TimeSpan EstimateTimeToPaint(double sqMeters);
    }

    class Iterator_Advanced
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            double bestPrice = 0;
            IPainter cheapest = null;

            foreach (IPainter painter in painters)
            {
                if (painter.IsAvailble)
                {
                    double price = painter.EstimateCompenstation(sqMeters);
                    if (cheapest == null || price < bestPrice)
                    {
                        cheapest = painter;
                    }
                }
            }

            return cheapest;
        }
    }


    class  IteratorDemo_Good // Sorting is resorces heavey yields O (N LogN), Better Idea is Picking
    {

        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailble)
                    .OrderBy(painter => painter.EstimateCompenstation(sqMeters))
                    .FirstOrDefault();
        }
    }

    class InterorDemo_Better
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailble)
                    .Aggregate((best, current) =>
                        best.EstimateCompenstation(sqMeters) < current.EstimateCompenstation(sqMeters) ? best : current);
            // throws exception if squence is empty
            // requires a non null answer
            //poor readability (Humans are better adapted to reading foreach loops)

        }
    }

    class InterorDemo_BetterStill
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailble)
                    //seeding aggreate so it does not throw exception on null or empty collection
                    .Aggregate((IPainter) null, (best, cur) =>
                        best == null ||
                        cur.EstimateCompenstation(sqMeters) < best.EstimateCompenstation(sqMeters)
                            ? cur
                            : best);

        }
    }

    // try 4
    public static class EnumberableExtenstions
    {
        //inside () is method signature
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
                sequence.Aggregate((T) null, (best, cur) =>
                    best == null || criterion(cur).CompareTo(criterion(best)) < 0 ? cur : best);
        // So basically this guys argurment is that exentions methods are infrastructure code with remains out of site 
        // and that this allows implementation code to remain clean. (which this is total bs)

        public static T WithMiniumFast<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
                sequence
                    .Select(obj => Tuple.Create(obj, criterion(obj)))
                    .Aggregate((Tuple<T, TKey>) null,
                        (best, current) => best == null || current.Item2.CompareTo(best.Item2) < 0 ? current : best)
                    .Item1;
    }


    class InterorDemo_BetterYet
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailble)
                    .WithMinimum(painter => painter.EstimateCompenstation(sqMeters));
        }
    }

    class InteratorDemo_BetterReally
    {
         private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
         {
             return
                 painters
                     .Where(painter => painter.IsAvailble)
                     .WithMiniumFast(painter => painter.EstimateCompenstation(sqMeters));
         }
    }
}

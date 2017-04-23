using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.StructureOperations
{
    public static class Client
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailble)
                    .WithMinimum(painter => painter.EstimateCompenstation(sqMeters));
        }

        private static IPainter FindFastestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailble)
                    .WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
        }

        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {

            TimeSpan time =
                TimeSpan.FromHours(
                    1/
                    painters
                        .Where(painter => painter.IsAvailble)
                        .Select(painter => 1/painter.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum()
                    );
            double cost =
            painters
                .Where(painter => painter.IsAvailble)
                .Select(painter =>
                    painter.EstimateCompenstation(sqMeters)/
                    painter.EstimateTimeToPaint(sqMeters).TotalHours*
                    time.TotalHours)
                .Sum();

            //Composite Pattern
            return new ProportinalPainter()
            {
                DollarsPerHOur = cost/time.TotalHours,
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours/sqMeters)
            };

        }

    }
}

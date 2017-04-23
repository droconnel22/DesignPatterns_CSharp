using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.StructureOperations
{
    //Mother classes or mother objects
    public static class CompositePainterFactory
    {

        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (sqMeters,sequence) => new Painters(sequence).GetAvailable().GetCheapestOne(sqMeters));

        public static IPainter CreateFastestSelector(IEnumerable<IPainter> painters) =>
                new CompositePainter<IPainter>(painters,
                    (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetFastestOne(sqMeters));

        public  static IPainter CreateGroup(IEnumerable<ProportinalPainter> painters) =>
            new CompositePainter<ProportinalPainter>(painters, (sqMeters, sequence) =>
            {
                TimeSpan time =
             TimeSpan.FromHours(
                 1 /
               painters
                     .Where(painter => painter.IsAvailble)
                     .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                     .Sum()
                 );
                double cost =
                  painters
                        .Where(painter => painter.IsAvailble)
                        .Select(painter =>
                            painter.EstimateCompenstation(sqMeters) /
                            painter.EstimateTimeToPaint(sqMeters).TotalHours *
                            time.TotalHours)
                        .Sum();

                //Composite Pattern
                return new ProportinalPainter()
                {
                    DollarsPerHOur = cost / time.TotalHours,
                    TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters)
                };
            });
    }
}

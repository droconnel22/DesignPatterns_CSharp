using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.ObjectOriented.Console.StructureOperations;
using IPainter = CodeWars.ObjectOriented.Console.StructureOperations.IPainter;

using ProportinalPainter = CodeWars.ObjectOriented.Console.StructureOperations.ProportinalPainter;

namespace CodeWars.ObjectOriented.Console.StrategyPattern
{
    class RefactoredCompositePainterFactory
    {
        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetCheapestOne(sqMeters));

        public static IPainter CreateFastestSelector(IEnumerable<IPainter> painters) =>
                new CompositePainter<IPainter>(painters,
                    (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetFastestOne(sqMeters));

        public static IPainter CreateGroup(IEnumerable<ProportinalPainter> painters) =>
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

            //what to combine and how to combine
            public static IPainter CombineProportional(IEnumerable<ProportinalPainter> painters) =>
                    new CombiningPainter<ProportinalPainter>(painters, new ProportionalPaintingScheduler());
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CodeWars.ObjectOriented.Console.StructureOperations;
using IPainter = CodeWars.ObjectOriented.Console.StructureOperations.IPainter;

namespace CodeWars.ObjectOriented.Console.StrategyPattern
{
    class ProportionalPaintingScheduler : IPaintingScheduler<ProportinalPainter>
    {
        public IEnumerable<PaintingTask<ProportinalPainter>> Schedule(double sqMeters,
            IEnumerable<ProportinalPainter> painters)
        {
            IEnumerable<Tuple<ProportinalPainter, double>> velocities =
                painters
                    .Select(painter =>
                        Tuple.Create(painter, sqMeters/painter.EstimateTimeToPaint(sqMeters).TotalHours))
                    .ToList();

            double totalVelocity = velocities.Sum(tuple => tuple.Item2);

            IEnumerable<PaintingTask<ProportinalPainter>> schedule =
                velocities
                    .Select(tuple =>
                        new PaintingTask<ProportinalPainter>(tuple.Item1, sqMeters*tuple.Item2/totalVelocity))
                    .ToList();

            return schedule;
        }
    }
}
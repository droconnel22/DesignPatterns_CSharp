using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.StructureOperations
{
    //How can group be a single painters?
    public class PaintingGroup : IPainter
    {
        private IEnumerable<IPainter> Painters { get; }

        public PaintingGroup(IEnumerable<IPainter> painters)
        {
            this.Painters = painters.ToList();
        }


        public IPainter Reduce(double sqMeters)
        {

            TimeSpan time =
                TimeSpan.FromHours(
                    1 /
                    this.Painters
                        .Where(painter => painter.IsAvailble)
                        .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum()
                    );
            double cost =
                this.Painters
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

        }

        public bool IsAvailble => this.Painters.Any(painter => painter.IsAvailble);

        public double EstimateCompenstation(double sqMeters) =>
            this.Reduce(sqMeters).EstimateCompenstation(sqMeters);

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            this.Reduce(sqMeters).EstimateTimeToPaint(sqMeters);
    }
}

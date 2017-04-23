using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.StructureOperations
{
   public class CompositePainter<TPainter> : IPainter
        where TPainter : IPainter
   {
        private IEnumerable<TPainter> Painters { get; }

        public Func<double,IEnumerable<TPainter>,IPainter>  Reduce { get; set; }

        public CompositePainter(IEnumerable<TPainter> painters, Func<double,IEnumerable<TPainter>,IPainter> reduce = null)
        {
            this.Painters = painters.ToList();
            this.Reduce = reduce;
        }

        public bool IsAvailble => this.Painters.Any(painter => painter.IsAvailble);

        public double EstimateCompenstation(double sqMeters) =>
            this.Reduce(sqMeters, this.Painters).EstimateCompenstation(sqMeters);

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            this.Reduce(sqMeters, this.Painters).EstimateTimeToPaint(sqMeters);
    }
}

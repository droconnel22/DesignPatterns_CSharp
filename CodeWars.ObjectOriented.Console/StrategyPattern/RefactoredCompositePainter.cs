using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPainter = CodeWars.ObjectOriented.Console.StructureOperations.IPainter;

namespace CodeWars.ObjectOriented.Console.StrategyPattern
{
    class RefactoredCompositePainter<TPainter> : IPainter
        where TPainter : IPainter
   {
        private IEnumerable<TPainter> Painters { get; }

        public Func<double,IEnumerable<TPainter>, IPainter>  Reduce { get; }

        public RefactoredCompositePainter(IEnumerable<TPainter> painters, Func<double,IEnumerable<TPainter>, IPainter> reduce)
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

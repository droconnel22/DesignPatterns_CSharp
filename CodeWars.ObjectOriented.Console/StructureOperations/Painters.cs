using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.StructureOperations
{
    //An abstraction of Painters
    // Code should read as you talk about it
    //Avoid articial mapping between spoken language and code
    // Design the consuming end first!!
    public class Painters
    {
        private IEnumerable<IPainter>  ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            this.ContainedPainters = painters.ToList();
        }

        public Painters GetAvailable() 
            => new Painters(this.ContainedPainters.Where(painter => painter.IsAvailble));

        public Painters CheckGetAvailable()
        {
            if (this.ContainedPainters.All(painter => painter.IsAvailble)) return this;
            return new Painters(this.ContainedPainters.Where(painter => painter.IsAvailble));
        }

        public IPainter GetCheapestOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(painter => painter.EstimateCompenstation(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));

    }
}

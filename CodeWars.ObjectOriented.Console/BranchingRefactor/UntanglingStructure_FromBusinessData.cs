using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.ObjectOriented.Console.BranchingRefactor
{
 
    public static  class UntanglingStructure_FromBusinessData
    {
        private static IPainter FindFastestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailble)
                    .WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));

        }
        /// <summary>
        /// 1. Each work paints part of the wall
        /// 2. Calculate time for entire work
        /// 3. Let each painter work that long
        /// 4. THeir total output will be equal to sqMeters
        /// Assumption: Painters work at constant speed.
        /// </summary>
        /// <param name="sqMeters"></param>
        /// <param name="painters"></param>

        private static IPainter WorkTogether(double sqMeters, IEnumerable<PropoertionalPainter> painters)
        {
            TimeSpan time =
                TimeSpan.FromHours(1/painters
                    .Where(painter => painter.IsAvailble)
                    .Select(painter => 1/painter.EstimateTimeToPaint(sqMeters).TotalHours)
                    .Sum());

            // now estimate dolalrs per hours foreach of the painters
        double cost =
            painters
                .Where(painter => painter.IsAvailble)
                .Select(
                    painter =>
                    painter.EstimateCompenstation(sqMeters)/
                    painter.EstimateTimeToPaint(sqMeters).TotalHours 
                    * time.TotalHours)
               .Sum();

            //Composite Pattern
            return new PropoertionalPainter()
            {
                DollarsPerHour = cost/time.TotalHours,
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours/sqMeters)
            };
        }
    }

    // Composite Pattern
    public class PropoertionalPainter: IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }
        public double DollarsPerHour { get; set; }
        public bool IsAvailble => true;

        public double EstimateCompenstation(double sqMeters) =>
            this.EstimateTimeToPaint(sqMeters).TotalHours*this.DollarsPerHour;
        
        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            TimeSpan.FromHours(this.TimePerSqMeter.TotalHours*sqMeters);

    }
}

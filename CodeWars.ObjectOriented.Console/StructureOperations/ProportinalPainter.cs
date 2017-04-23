using System;

namespace CodeWars.ObjectOriented.Console.StructureOperations
{
    // Can be single object or a facade holding a group of objects
    // Example of Composite Pattern
    public class ProportinalPainter : IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }
        public double DollarsPerHOur { get; set; }

        public bool IsAvailble => true;

        public double EstimateCompenstation(double sqMeters) =>
            this.EstimateTimeToPaint(sqMeters).TotalHours*this.DollarsPerHOur;

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            TimeSpan.FromHours(this.TimePerSqMeter.TotalHours * sqMeters);

    }
}
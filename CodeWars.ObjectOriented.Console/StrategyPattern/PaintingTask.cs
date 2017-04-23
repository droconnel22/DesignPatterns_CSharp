using CodeWars.ObjectOriented.Console.BranchingRefactor;
using IPainter = CodeWars.ObjectOriented.Console.StructureOperations.IPainter;

namespace CodeWars.ObjectOriented.Console.StrategyPattern
{
    class PaintingTask<TPainter> where TPainter : IPainter
    {
        public TPainter Painter { get; }
        public double SqureMeters { get; }

        public PaintingTask(TPainter painter, double sqMeters)
        {
            this.Painter = painter;
            this.SqureMeters = sqMeters;
        }

    }
}
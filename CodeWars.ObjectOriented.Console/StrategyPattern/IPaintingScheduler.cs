using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IPainter = CodeWars.ObjectOriented.Console.StructureOperations.IPainter;

namespace CodeWars.ObjectOriented.Console.StrategyPattern
{
    interface IPaintingScheduler<TPainter> where TPainter : IPainter
    {
        IEnumerable<PaintingTask<TPainter>> Schedule(double sqMeters, IEnumerable<TPainter> painters);
    }
}

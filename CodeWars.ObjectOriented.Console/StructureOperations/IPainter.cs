using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.StructureOperations
{
    public interface IPainter
    {
        bool IsAvailble { get; }
        double EstimateCompenstation(double sqMeters);
        TimeSpan EstimateTimeToPaint(double sqMeters);
    }
}

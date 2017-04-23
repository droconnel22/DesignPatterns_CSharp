using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ObjectOriented.Console.StructureOperations
{
    public static class BetterClient
    {

        static void Main(string[] args)
        {
            IEnumerable<ProportinalPainter> painters = new ProportinalPainter[10];

            IPainter compositeGroup = CompositePainterFactory.CreateGroup(painters);

            IPainter cheapestPainter = CompositePainterFactory.CreateCheapestSelector(painters);

            IPainter fastestPainter = CompositePainterFactory.CreateFastestSelector(painters);

        }
      
    }
}

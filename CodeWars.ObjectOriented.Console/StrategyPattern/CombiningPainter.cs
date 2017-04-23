using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.ObjectOriented.Console.StructureOperations;
using IPainter = CodeWars.ObjectOriented.Console.StructureOperations.IPainter;
using ProportinalPainter = CodeWars.ObjectOriented.Console.StructureOperations.ProportinalPainter;


namespace CodeWars.ObjectOriented.Console.StrategyPattern
{
    class CombiningPainter<TPainter> : CompositePainter<TPainter>
        where TPainter : IPainter
    {

       private IPaintingScheduler<TPainter> ScheduleWork { get; }

        public CombiningPainter(IEnumerable<TPainter> painters, IPaintingScheduler<TPainter> ScheduleWork) 
            : base(painters)
        {
            base.Reduce = this.Combine;
            this.ScheduleWork = ScheduleWork;
        }


        public IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            IEnumerable<TPainter> availablePainters = painters.Where(painter => painter.IsAvailble);

            IEnumerable<PaintingTask<TPainter>> schedule = this.ScheduleWork.Schedule(sqMeters, availablePainters);
            
            TimeSpan time = schedule.Max(paintingTask => paintingTask.Painter.EstimateTimeToPaint(paintingTask.SqureMeters));
            double cost = schedule.Sum(paintingTask => paintingTask.Painter.EstimateCompenstation(paintingTask.SqureMeters));
            
            //Composite Pattern
            return new ProportinalPainter()
            {
                DollarsPerHOur = cost / time.TotalHours,
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters)
            };
        }
    }
}

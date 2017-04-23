using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
   public class Application
   {

       private IVacationPartFactory partFactory;

       public Application(IVacationPartFactory vacationPartFactory)
       {
           this.partFactory = vacationPartFactory;
       }


       public void Run()
       {
           VacationSpecificationBuilder builder =
                new VacationSpecificationBuilder(
                    this.partFactory, 
                    new DateTime(2017,7,11),
                    15,
                "Crowded City",
                "Seatown");

            builder.SelectHotel("Samll one");
            builder.SelectAirplane("Noisy one");

           VacationSpecification spec = builder.BuildVacation();
       }
    }
}

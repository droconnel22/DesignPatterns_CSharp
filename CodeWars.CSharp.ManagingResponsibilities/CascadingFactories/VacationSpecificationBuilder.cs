using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    public class VacationSpecificationBuilder
    {
       
        private IList<IVacationPart> parts = new List<IVacationPart>();

        private readonly IVacationPartFactory vacationPartFactory;

        private DateTime arrivalDate;
        private int totalNights;

        private string livingTown;
        private string destinationTown;

        public VacationSpecificationBuilder(
            IVacationPartFactory vacationPartFactory,
            DateTime arrivalDate, 
            int totalNights,
            string livingTown, 
            string destinationTown)
        {

            this.vacationPartFactory = vacationPartFactory;

            this.arrivalDate = arrivalDate;
            this.totalNights = totalNights;

            this.livingTown = livingTown;
            this.destinationTown = destinationTown;
        }


        public void SelectHotel(string hotelName)
        {
            IVacationPart part=
                this.vacationPartFactory
                    .CreateHotelReservation(this.destinationTown, hotelName,
                        this.arrivalDate,
                        this.DepartureDate);

            this.parts.Add(part);
        }

        public void SelectAirplane(string companyName)
        {
            this.parts.Add(CreateFlightToDestination(companyName));
            this.parts.Add(CreateFlightToOrigin(companyName));
        }

        private IVacationPart CreateFlightToOrigin(string companyName) => 
            this.vacationPartFactory
                   .CreateFlight(companyName, this.destinationTown, this.livingTown,this.DepartureDate);

        private IVacationPart CreateFlightToDestination(string companyName) =>
            this.vacationPartFactory
            .CreateFlight(companyName, this.livingTown, this.destinationTown,this.arrivalDate);

        private DateTime DepartureDate
        {
            get { return this.arrivalDate.AddDays(this.totalNights); }
        }

        public VacationSpecification BuildVacation()
        {
           foreach(IVacationPart part in this.parts)
                part.Purchase();
           return  new VacationSpecification(this.parts);
        }
    }
}

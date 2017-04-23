using System;

namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    public class VacationPartFactory : IVacationPartFactory
    {

        private IHotelService hotelService;

        private IHotelSelector hotelSelector;

        private IAirplaneService airplaneService;


        public VacationPartFactory(
            IHotelService hotelService,
            IHotelSelector hotelSelector,
             IAirplaneService airplaneService)
        {
            this.hotelService = hotelService;
            this.hotelSelector = hotelSelector;
            this.airplaneService = airplaneService;
        }


        public IVacationPart CreateHotelReservation(string town, string hotelName, DateTime arrivalDate, DateTime leaveDate) =>
            this.hotelService.MakeBooking(this.hotelSelector.SelectHotel(town, hotelName), arrivalDate, leaveDate);

        public IVacationPart CreateFlight(string companyName, string source, string destination, DateTime date) => 
            this.airplaneService.SelectFlight(companyName, source, destination, date);

        public IVacationPart CreateFerryBooking(string lineName, bool fromMainland, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IVacationPart CreateDailyTrip(string tripName, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IVacationPart CreateMassage(string salon, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
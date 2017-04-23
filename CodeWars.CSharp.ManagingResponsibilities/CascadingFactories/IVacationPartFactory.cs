using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    public interface IVacationPartFactory
    {
        IVacationPart CreateHotelReservation(string town, string hotelName, DateTime arrivalDate, DateTime leaveDate);

        IVacationPart CreateFlight(string companyName, string source, string destination, DateTime date);

        IVacationPart CreateFerryBooking(string lineName, bool fromMainland, DateTime date);

        IVacationPart CreateDailyTrip(string tripName, DateTime date);

        IVacationPart CreateMassage(string salon, DateTime date);
    }
}

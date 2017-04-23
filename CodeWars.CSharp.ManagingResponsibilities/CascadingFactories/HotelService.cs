using System;

namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    public class HotelService : IHotelService
    {
        public IVacationPart MakeBooking(HotelInfo hotelInfo, DateTime checkin, DateTime checkout)
        {
            throw new NotImplementedException();
        }
    }
}
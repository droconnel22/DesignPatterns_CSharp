using System;

namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    public interface IHotelService
    {
        IVacationPart MakeBooking(HotelInfo hotelInfo, DateTime checkin, DateTime checkout);
      
    }
}
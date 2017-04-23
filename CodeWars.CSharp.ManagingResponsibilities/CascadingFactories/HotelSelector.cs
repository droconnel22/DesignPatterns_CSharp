namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    public class HotelSelector : IHotelSelector
    {
        public HotelInfo SelectHotel(string destinationTown, string hotelName) => new HotelInfo();
    }
}
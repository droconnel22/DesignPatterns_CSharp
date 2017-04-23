namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    public interface IHotelSelector
    {
        HotelInfo SelectHotel(string destinationTown, string hotelName);
    }
}
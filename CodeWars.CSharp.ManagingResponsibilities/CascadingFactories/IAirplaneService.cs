using System;

namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    public interface IAirplaneService
    {
        IVacationPart SelectFlight(string companyName, string origin, string destination, DateTime travelDate);
    }
}
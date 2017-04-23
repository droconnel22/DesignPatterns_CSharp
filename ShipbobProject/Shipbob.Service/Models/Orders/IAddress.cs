namespace Shipbob.Service.Models.Orders
{
   public  interface IAddress
    {
        int AddressId { get; }
        string Name { get; }

        string Street { get; }

        string State { get; }
     
        string  City { get; }

        string PostalCode { get; }
    }
}

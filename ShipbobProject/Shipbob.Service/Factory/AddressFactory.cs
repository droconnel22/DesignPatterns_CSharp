using Shipbob.Data.Entities;
using Shipbob.Service.Models.Orders;

namespace Shipbob.Service.Factory
{
    internal class AddressFactory
    {
        public static AddressEntity CreateAddress(IAddress address) => new AddressEntity()
        {
            AddressId = 0,
            City = address.City,
            Name = address.Name,
            PostalCode = address.PostalCode,
            State = address.State,
            Street = address.Street
        };

        public static IAddress CreateAddress(AddressEntity entity) => 
            new Address(entity.AddressId, entity.Name,entity.Street,entity.State,entity.City,entity.PostalCode);
    }
}
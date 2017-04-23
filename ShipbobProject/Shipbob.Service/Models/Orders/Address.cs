using System;

namespace Shipbob.Service.Models.Orders
{
    //Do not want client to extend this class
    public sealed class Address : IAddress
    {
        public  int AddressId { get; }
        public string Name { get; }
        public string Street { get; }
        public string State { get; }
        public string City { get; }
        public string PostalCode { get; }

        public Address(int addressId, string name, string street, string state, string city, string postalCode)
        {

            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if(string.IsNullOrEmpty(street)) throw new ArgumentNullException(nameof(street));
            if(string.IsNullOrEmpty(state)) throw new ArgumentNullException(nameof(state));
            if(string.IsNullOrEmpty( city)) throw new ArgumentNullException(nameof(city));
            if(string.IsNullOrEmpty(postalCode)) throw  new ArgumentNullException(nameof(postalCode));

            this.AddressId = addressId;
            this.Name = name;
            this.Street = street;
            this.State = state;
            this.City = city;
            this.PostalCode = postalCode;
        }
    }
}
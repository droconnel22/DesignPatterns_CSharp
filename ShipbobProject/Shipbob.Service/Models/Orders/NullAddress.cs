namespace Shipbob.Service.Models.Orders
{
    public sealed class NullAddress : IAddress
    {

        private static NullAddress instance;

        private NullAddress() { }


        public static IAddress GetInstance
        {
            get
            {
                if(instance == null)
                    instance = new NullAddress();
                return instance;
            }
        }

        public int AddressId => 0;
        public string Name => string.Empty;
        public string Street => string.Empty;
        public string State => string.Empty;
        public string City => string.Empty;
        public string PostalCode => string.Empty;
    }
}
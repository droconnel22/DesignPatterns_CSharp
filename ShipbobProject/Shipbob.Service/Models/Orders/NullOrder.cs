using System.Collections.Generic;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Models.Orders
{
    internal sealed  class NullOrder : IOrder
    {
        private static NullOrder Instance;

        private NullOrder()
        {
            
        }

        public static IOrder  GetInstance 
        {
            get
            {
                if(Instance == null)
                    Instance = new NullOrder();
                return Instance;
            }
        }

        public int OrderId => 0;
        public string TrackingId => string.Empty;
        public IAddress OrderAddress => NullAddress.GetInstance;

        public IEnumerable<IItem> Items => new List<IItem>();
    }
}
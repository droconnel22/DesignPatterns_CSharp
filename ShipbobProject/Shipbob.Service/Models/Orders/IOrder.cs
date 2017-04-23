using System.Collections.Generic;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Models.Orders
{
    public interface IOrder
    {
        int OrderId { get; }
        string TrackingId { get; }
      
        IAddress OrderAddress { get; }
        IEnumerable<IItem> Items { get; }
    }
}
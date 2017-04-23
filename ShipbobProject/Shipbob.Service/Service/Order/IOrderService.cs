using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Service.Models.Orders;
using Shipbob.Service.Service.Inventory;

namespace Shipbob.Service.Service.Order
{
    public interface IOrderService
    {
        IOrder currentOrder { get; }

        IOrderService SetAllItemsToSold();

        Task<bool> PlaceOrderAsync();

        IOrderService UpdateInventoryState(Func<IInventoryService> checkInventoryState);

        IOrderService SetCurrentOrder(IOrder order);
    }
}

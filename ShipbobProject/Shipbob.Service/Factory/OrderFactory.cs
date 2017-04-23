using System;
using System.Collections.Generic;
using Shipbob.Data.Entities;
using Shipbob.Service.Models.Orders;

namespace Shipbob.Service.Factory
{
    //could be made static, structure map will enforce singleton pattern desired.
    internal static class OrderFactory 
    {
        
        public static IOrder CreateOrder(OrderEntity entity) => 
            new Order(entity.OrderId, entity.TrackingId, AddressFactory.CreateAddress(entity.AddressEntity), InventoryFactory.Create(entity.Items));

        public static OrderEntity CreateOrder(IOrder order) =>
            new OrderEntity()
            {
                OrderId = order.OrderId,
                TrackingId = order.TrackingId,
                AddressEntity = AddressFactory.CreateAddress(order.OrderAddress),
                CreatedOrder = DateTime.UtcNow,
                Items = new List<ItemEntity>(InventoryFactory.Create(order.Items))
            };

    }
}
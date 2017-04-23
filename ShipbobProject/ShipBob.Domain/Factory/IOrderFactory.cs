using Shipbob.Service.Models.Orders;
using ShipBob.Domain.ViewModels;
using System;
using ShipBob.Domain.Common;

namespace ShipBob.Domain.Factory
{
    internal static class OrderFactory
    {
       public static IOrder Create(OrderViewModel orderViewModel) =>
            new Order(0,orderViewModel.TrackingId,
                new Address(0,orderViewModel.OrderAddress.AddressName,orderViewModel.OrderAddress.StreetAddress,orderViewModel.OrderAddress.State,orderViewModel.OrderAddress.City,orderViewModel.OrderAddress.ZipCode),
                orderViewModel.Items.ConvertToModel());
    }
}
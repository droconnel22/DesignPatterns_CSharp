using System;
using System.Collections.Generic;
using System.Linq;
using Shipbob.Data.Migrations;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Models.Orders
{
    public sealed class Order : IOrder, IEquatable<Order>
    {
        public int OrderId { get; }
        public string TrackingId { get; }
        public IAddress OrderAddress { get; }
        public IEnumerable<IItem> Items { get; }
      

        public Order(int orderId,string trackingId,  IAddress orderAddress, IEnumerable<IItem> items)
        {

            if(string.IsNullOrWhiteSpace(trackingId)) throw  new ArgumentNullException(nameof(trackingId));
            if(orderAddress == null) throw  new ArgumentNullException(nameof(orderAddress));
            if(items == null) throw new ArgumentNullException(nameof(items));

            this.OrderId = orderId;
            this.TrackingId = trackingId;
            this.OrderAddress = orderAddress;
         
            this.Items = items;
        }

        public bool Equals(Order other)=> 
            string.Equals(this.TrackingId, other.TrackingId, StringComparison.InvariantCultureIgnoreCase);

        public override bool Equals(object obj) => 
            this.Equals(obj) && obj is Order;

        public override string ToString() =>
            $"This order with tracking Id {this.TrackingId} and address of {this.OrderAddress.City} with {this.Items.Count()} number of items";

        public override int GetHashCode() =>
            base.GetHashCode();
    }
}
 
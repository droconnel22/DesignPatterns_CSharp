using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipbob.Data.Entities;
using Shipbob.Data.Repository;
using Shipbob.Service.Factory;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Models.Orders;
using Shipbob.Service.Service.Inventory;

namespace Shipbob.Service.Service.Order
{

    public class OrderService : IOrderService
    {
        public IOrder currentOrder { get; private set; }

        private readonly BaseRepository<OrderEntity> orderRepository;
      
        public OrderService()
        {
            this.orderRepository = new BaseRepository<OrderEntity>();
            this.currentOrder = NullOrder.GetInstance;
        }

        public IOrderService SetCurrentOrder(IOrder order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            this.currentOrder = order;
            return this;
        }

        public IOrderService SetAllItemsToSold()
        {
            this.currentOrder.Items.Select(i => new Item(i.ItemId, true, i.ItemColor, i.ItemType));
            return this;
        }

        public  async Task<bool> PlaceOrderAsync()
        {
            if(currentOrder is NullOrder) throw new InvalidOperationException();
            var result =  await this.orderRepository.AddEntityAsync(OrderFactory.CreateOrder(this.currentOrder));
            if (result) this.currentOrder = NullOrder.GetInstance;
            return result;
        }
       

        public IOrderService UpdateInventoryState(Func<IInventoryService> checkInventoryState)
        {
            checkInventoryState();
            return this;
        }

    }
}

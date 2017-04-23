using System.Threading.Tasks;
using Shipbob.Service.CacheController;
using Shipbob.Service.Service;
using Shipbob.Service.Service.Inventory;
using Shipbob.Service.Service.Order;
using ShipBob.Domain.ViewModels;
using Shipbob.Service.ServiceBuilder;
using ShipBob.Domain.Common;

namespace ShipBob.Domain.Manager
{
    public class Manager : IManager
    {
        private IInventoryService inventoryService;

        private readonly IOrderService orderService;

        private readonly IInventoryServiceBuilder inventoryServiceBuilder;

        public Manager(IInventoryServiceBuilder builder, IOrderService orderService)
        {
            this.inventoryServiceBuilder = builder;
            this.orderService = orderService;
        }
       
        public async Task InitailzeAsync() => this.inventoryService = 
            await this.inventoryServiceBuilder
            .SetCachingService(NotImplementedCacheController.GetInstance)
            .BuildAsync();

        public async Task<InventoryViewModel> GetInventoryAsync() =>
          (await this.inventoryService
                .CheckInventoryState()
                .UpdateInventoryAsync())
                .TakeInventory()
                .ConvertToItemViewModels();

        public async Task<bool> PlaceOrder(OrderViewModel orderViewModel) =>
            await this.orderService
            .SetCurrentOrder(orderViewModel.ConvertToOrderModel())
            .SetAllItemsToSold()
            .PlaceOrderAsync();

        public async Task<InventoryCountViewModel> CheckInventoryAsync() =>
            (await this.inventoryService
                .GetNewInventoryCheckAsync())
                .ConvertToInventoryViewModel();
    }

 
}
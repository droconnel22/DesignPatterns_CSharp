using Shipbob.Service.Service;
using System.Threading.Tasks;
using Shipbob.Service.ServiceStrategies;
using Shipbob.Service.CacheController;
using Shipbob.Service.Models.InventoryStates;
using Shipbob.Service.Service.Inventory;
using StructureMap;

namespace Shipbob.Service.ServiceBuilder
{

    public class InventoryServiceBuilder : IInventoryServiceBuilder
    {
        private ICacheController cacheStrategy { get; set; }

        private readonly IInventoryServiceStrategy inventoryServiceStrategy;

        private readonly IInventoryState inventoryState;

        public InventoryServiceBuilder(IInventoryServiceStrategy strategy)
        {
            this.inventoryServiceStrategy = strategy;
            this.cacheStrategy = NotImplementedCacheController.GetInstance;
            this.inventoryState = InitialzedInventoryState.GetInstance;
        }

        public IInventoryServiceBuilder SetCachingService(ICacheController cacheController = null)
        {
            if (cacheController != null) this.cacheStrategy = cacheController;
            return this;
        }
       
        /*
         * 1.Request From Database # of items that wer not sold
         * 2. Set Order State based on availability of items
         * 3. Cache Inventory
         * 100 Red baseballs, 100 Blue Bats, and 100 White Hats.
         */
        public async Task<IInventoryService> BuildAsync() => 
            new InventoryService(this.cacheStrategy,await this.inventoryServiceStrategy.BuildInventory(), this.inventoryState);
    }
}

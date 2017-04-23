using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Service.Configuration;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.ServiceStrategies;

namespace Shipbob.Service.Models.InventoryStates
{
    internal class LowInventoryState : BaseInventoryState
    {
        public LowInventoryState(IServiceConfiguration configuration)
            : base(configuration)
        {
            base.InventoryServiceStrategy = new RefreshInventoryServiceStrategy();
        }

        public override int ReturnToClient() => this.ServiceConfiguration.LowSendInventoryToClient;

        public override Task<IDictionary<string, Queue<IItem>>> UpdateInventoryCacheAsync(IReadOnlyDictionary<string, Queue<IItem>> itemDictonary) =>
            this.InventoryServiceStrategy.BuildInventory(25);

    }
}
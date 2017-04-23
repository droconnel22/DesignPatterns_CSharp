using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipbob.Service.Configuration;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.ServiceStrategies;

namespace Shipbob.Service.Models.InventoryStates
{
    internal class EmptyInventoryState : BaseInventoryState
    {

        public EmptyInventoryState(IServiceConfiguration configuration) 
            : base(configuration)
        {
            base.InventoryServiceStrategy = new RefreshInventoryServiceStrategy();
        }

        public override int ReturnToClient() => this.ServiceConfiguration.EmptySendInventoryToClient;

        public override Task<IDictionary<string, Queue<IItem>>> UpdateInventoryCacheAsync(
            IReadOnlyDictionary<string, Queue<IItem>> itemDictonary) => this.InventoryServiceStrategy.BuildInventory(50);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Service.Configuration;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Models.InventoryStates
{
    internal class HighDemandInventoryState : BaseInventoryState
    {
        public HighDemandInventoryState(IServiceConfiguration configuration) : base(configuration)
        {

        }

        public override int ReturnToClient() => this.ServiceConfiguration.NormalSendInventoryToClient;
        public override Task<IDictionary<string, Queue<IItem>>> UpdateInventoryCacheAsync(IReadOnlyDictionary<string, Queue<IItem>> itemDictonary)
        {
            throw new System.NotImplementedException();
        }
    }
}
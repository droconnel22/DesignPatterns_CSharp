using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Service.Inventory;

namespace Shipbob.Service.Models.InventoryStates
{
    public interface IInventoryState
    {
        IInventoryState CheckInventoryState(IReadOnlyDictionary<string, Queue<IItem>> itemDictonary);

        IInventoryState SetToLowInventory();

        IInventoryState SetToNormalInventory();

        IInventoryState SetToHighDemainInventory();

        IInventoryState SetToEmptyInventoryState();

        Task<IDictionary<string, Queue<IItem>>> UpdateInventoryCacheAsync(IReadOnlyDictionary<string, Queue<IItem>> itemDictonary);

        int ReturnToClient();

    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Service.Inventory
{
    public interface IInventoryService
    {
        IEnumerable<IItem> TakeInventory();

        IInventoryService CheckInventoryState();

        Task<IInventoryService> UpdateInventoryAsync();

        Task<IInventoryService> UpdateInventoryCacheAsync();

        Task<InventoryCount> GetNewInventoryCheckAsync();
   
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Shipbob.Service.CacheController;
using Shipbob.Service.Common;
using Shipbob.Service.Models;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Models.InventoryStates;

namespace Shipbob.Service.Service.Inventory
{

    public class InventoryService : IInventoryService        
    {
        private IInventoryState InventoryState { get; set; }

        private IReadOnlyDictionary<string, Queue<IItem>> itemDictonary { get; set; }

        private readonly ICacheController cacheStrategy;

        public InventoryService(ICacheController cacheStrategy, IDictionary<string, Queue<IItem>> dictionary, IInventoryState state)
        {
            if(dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            this.cacheStrategy = cacheStrategy;
            this.itemDictonary = new ReadOnlyDictionary<string, Queue<IItem>>(dictionary);
            this.InventoryState = state; 
        }
        
        public IInventoryService CheckInventoryState()
        {
            this.InventoryState = this.InventoryState.CheckInventoryState(this.itemDictonary);
            return this;
        }

        public async Task<IInventoryService> UpdateInventoryAsync() => 
            new InventoryService(this.cacheStrategy, await this.InventoryState.UpdateInventoryCacheAsync(this.itemDictonary), this.InventoryState);

        //TODO Not implemented fully
        public async Task<IInventoryService> UpdateInventoryCacheAsync()
        {
            this.cacheStrategy.UpdateCache(this.itemDictonary);
            return this;
        }

        //Tuples are great for prototyping objects, but should be avoided for production code.
       public IEnumerable<IItem> TakeInventory()
        {
            
           var itemsToClient = new List<IItem>();
           foreach (var key in this.itemDictonary.Keys)
           {
                itemsToClient.AddRange(this.itemDictonary[key].TakeFromQueue(this.InventoryState.ReturnToClient()));
           }
           return itemsToClient;
        }

        public async Task<InventoryCount> GetNewInventoryCheckAsync() => new InventoryCount(itemDictonary.GetInventoryCounts());
        
    }
}

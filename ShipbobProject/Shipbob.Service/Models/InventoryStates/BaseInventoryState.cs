using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using Shipbob.Service.Configuration;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.ServiceStrategies;

namespace Shipbob.Service.Models.InventoryStates
{
   internal abstract class BaseInventoryState : IInventoryState
   {

       protected readonly IServiceConfiguration ServiceConfiguration;

       protected IInventoryServiceStrategy InventoryServiceStrategy;
   

       protected BaseInventoryState(IServiceConfiguration configuration)
       {
            this.ServiceConfiguration = new ServiceConfiguration();
            this.InventoryServiceStrategy = new DefaultInventoryStrategy(new ServiceConfiguration());
       }
     
       public IInventoryState SetToLowInventory() => new LowInventoryState(this.ServiceConfiguration);
       public IInventoryState SetToNormalInventory() => new NormalInventoryState(this.ServiceConfiguration);
       public IInventoryState SetToHighDemainInventory() => new HighDemandInventoryState(this.ServiceConfiguration);
       public IInventoryState SetToEmptyInventoryState()=> new EmptyInventoryState(this.ServiceConfiguration);

     
       public virtual IInventoryState CheckInventoryState(IReadOnlyDictionary<string, Queue<IItem>> itemDictonary)
       {
            var countDic = itemDictonary.ToDictionary(d => d.Key, d => d.Value.Count);
            if (countDic.Values.Any(x => x == 0)) return this.SetToEmptyInventoryState();
            if (countDic.Values.Any(x => x < 6)) return this.SetToLowInventory();
            return this.SetToNormalInventory(); 
       }

       public abstract int ReturnToClient();

        //Default
       public virtual Task<IDictionary<string, Queue<IItem>>> UpdateInventoryCacheAsync(
           IReadOnlyDictionary<string, Queue<IItem>> itemDictonary) =>
               this.InventoryServiceStrategy.BuildInventory();



   }
}

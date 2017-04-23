using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Data.Entities;
using Shipbob.Service.Factory;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Common
{
   internal static class ServiceExtensions
   {
       public static Queue<IItem> ConvertToModel(this IEnumerable<ItemEntity> entities) => InventoryFactory.CreateQueue(entities);

       public static IEnumerable<ItemEntity> ConvertToEntity(this IEnumerable<IItem> items)=> InventoryFactory.Create(items);

       public static IEnumerable<IItem> TakeFromQueue(this Queue<IItem> itemQueue, int count)
       {
            for (int i = 0; i < count && itemQueue.Count > 0; i++)
                yield return itemQueue.Dequeue();
        }


        public static IDictionary<string,int> GetInventoryCounts(this IReadOnlyDictionary<string,Queue<IItem>> itemDictionary)
            => itemDictionary.ToDictionary(g => g.Key, g => g.Value.Count());





    }
}

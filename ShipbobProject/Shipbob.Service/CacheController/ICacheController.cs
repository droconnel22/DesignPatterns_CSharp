using System.Collections.Generic;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Models.Orders;

namespace Shipbob.Service.CacheController
{
    public interface ICacheController
    {
        bool UpdateCache(IReadOnlyDictionary<string, Queue<IItem>> items);

        IDictionary<string, Queue<IItem>> GetFromCache();
     
    }
}
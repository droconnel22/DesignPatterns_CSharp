using System.Collections.Generic;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Models.Orders;
using Shipbob.Service.Service;

namespace Shipbob.Service.CacheController
{
    public sealed class NotImplementedCacheController : ICacheController
    {
        private static NotImplementedCacheController instance;

        private NotImplementedCacheController()
        {
            
        }

        public static ICacheController GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new NotImplementedCacheController();
                return instance;
            }
        }
        public bool UpdateCache(IReadOnlyDictionary<string, Queue<IItem>> items) => false;

        public IDictionary<string, Queue<IItem>> GetFromCache() => new Dictionary<string, Queue<IItem>>();
    }
}
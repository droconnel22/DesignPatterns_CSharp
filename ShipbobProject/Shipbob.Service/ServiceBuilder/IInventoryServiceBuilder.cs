using Shipbob.Service.Service;
using System.Threading.Tasks;
using Shipbob.Service.CacheController;
using Shipbob.Service.Service.Inventory;
using Shipbob.Service.ServiceStrategies;

namespace Shipbob.Service.ServiceBuilder
{
    public interface IInventoryServiceBuilder
    {
        IInventoryServiceBuilder SetCachingService(ICacheController cacheController);

        Task<IInventoryService> BuildAsync();
       
    }
}

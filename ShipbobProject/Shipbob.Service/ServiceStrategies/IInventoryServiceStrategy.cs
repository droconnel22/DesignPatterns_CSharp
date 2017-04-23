using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.ServiceStrategies
{
    public interface IInventoryServiceStrategy
    {
        Task<IDictionary<string, Queue<IItem>>> BuildInventory(int Take = 0);
    }
}

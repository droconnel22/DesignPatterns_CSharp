using System.Threading.Tasks;
using ShipBob.Domain.ViewModels;

namespace ShipBob.Domain.Manager
{
   public  interface IManager
   {
       Task InitailzeAsync();

        Task<InventoryViewModel> GetInventoryAsync();

        Task<bool> PlaceOrder(OrderViewModel orderViewModel);

        Task<InventoryCountViewModel> CheckInventoryAsync();
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Models.Orders;
using Shipbob.Service.Service;
using ShipBob.Domain.Factory;
using ShipBob.Domain.ViewModels;

namespace ShipBob.Domain.Common
{
    internal static class ManagerExtensions
    {
        public static InventoryViewModel ConvertToItemViewModels(this IEnumerable<IItem> items) => InventoryFactory.Create(items);

        public static InventoryCountViewModel ConvertToInventoryViewModel(this InventoryCount model) => InventoryFactory.Create(model);

        public static IOrder ConvertToOrderModel(this OrderViewModel orderViewModel)=> OrderFactory.Create(orderViewModel);

        public static IEnumerable<IItem> ConvertToModel(this IEnumerable<ItemViewModel> orderViewModels)=> orderViewModels.Select(ItemFactory.Create);

    }
}

using System.Collections.Generic;
using Shipbob.Service.Models.Inventory;
using ShipBob.Domain.ViewModels;
using System;
using System.Linq;

namespace ShipBob.Domain.Factory
{
    public static class InventoryFactory
    {

        //Reiterating here that tuples are great for prototyping objects but should never be sent to production code.
        public static InventoryViewModel Create(this IEnumerable<IItem> items) => new InventoryViewModel()
        {
            Items = items.Select(ItemFactory.Create)
        };

        public static InventoryCountViewModel Create(this InventoryCount inventoryCount)
        {
            var viewModel= new InventoryCountViewModel();
            foreach (KeyValuePair<string, int> keyValuePair in inventoryCount.inventoryCounts)
            {
                viewModel.InventoryCounts.Add(new Tuple<string, int>(keyValuePair.Key,keyValuePair.Value));
            }
            return viewModel;
        }
    }
}
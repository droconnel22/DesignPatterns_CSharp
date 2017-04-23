using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Service.Models.Inventory;
using ShipBob.Domain.ViewModels;

namespace ShipBob.Domain.Factory
{
    internal static class ItemFactory
    {
        public static ItemViewModel Create(IItem model) => new ItemViewModel()
        {
            IsSold = model.IsSold,
            ItemColor = model.ItemColor,
            ItemId = model.ItemId,
            ItemType = model.ItemType
        };

        public static IItem Create(ItemViewModel viewModel) => new Item(viewModel.ItemId,viewModel.IsSold, viewModel.ItemColor,viewModel.ItemType);
    }
}

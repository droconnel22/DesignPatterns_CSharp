using System;
using System.Collections.Generic;

namespace ShipBob.Domain.ViewModels
{
    public class InventoryCountViewModel
    {
        public ICollection<Tuple<string, int>> InventoryCounts { get; set; }

        public InventoryCountViewModel()
        {
            this.InventoryCounts = new List<Tuple<string, int>>();
        }
    }
}
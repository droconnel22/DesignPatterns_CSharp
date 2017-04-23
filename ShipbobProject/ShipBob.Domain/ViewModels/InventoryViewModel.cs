using System.Collections.Generic;

namespace ShipBob.Domain.ViewModels
{
    public class InventoryViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }
        
        public InventoryViewModel()
        {
            this.Items = new List<ItemViewModel>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipbob.Service.Models.Inventory
{
    public class InventoryCount
    {

        public IReadOnlyDictionary<string, int> inventoryCounts { get; }

        public InventoryCount(IDictionary<string,int> inventory)
        {
            this.inventoryCounts = new ReadOnlyDictionary<string, int>(inventory);
        }

    }
}

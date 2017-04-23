using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipbob.Service.ServiceStrategies
{
    //this should be set for the state
    public interface IInventoryBehaviorStrategy
    {
        TimeSpan TimeBetweenOrders { get; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipbob.Service.Configuration
{
    public interface IServiceConfiguration
    {
        int LoadItemCountFromDatabase { get; }

        int NormalSendInventoryToClient { get; }

        int LowSendInventoryToClient { get; }

        int EmptySendInventoryToClient { get; }
        int WhenInventoryLowTakeThisFromDb { get;}
    }
}

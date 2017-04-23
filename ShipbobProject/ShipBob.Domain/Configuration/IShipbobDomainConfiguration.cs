using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBob.Domain.Configuration
{
    internal interface IShipbobDomainConfiguration
    {
        int LoadItemCountFromDatabase { get; }
    }
}

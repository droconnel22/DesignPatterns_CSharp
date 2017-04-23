using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack;
using Shipbob.Service.Configuration;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.ServiceStrategies;

namespace Shipbob.Service.Models.InventoryStates
{
    internal class NormalInventoryState : BaseInventoryState
    {
        public NormalInventoryState(IServiceConfiguration configuration)
            : base(configuration){}

        public override int ReturnToClient() => this.ServiceConfiguration.NormalSendInventoryToClient;

    }
}
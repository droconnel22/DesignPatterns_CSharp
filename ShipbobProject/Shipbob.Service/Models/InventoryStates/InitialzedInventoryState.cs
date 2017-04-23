using System;
using System.Collections.Generic;
using System.Linq;
using Shipbob.Service.Configuration;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.Models.InventoryStates
{
    internal sealed class InitialzedInventoryState : BaseInventoryState
    {

        private static InitialzedInventoryState instance;

        private InitialzedInventoryState(IServiceConfiguration configuration)
            : base(configuration)
        {
        }

        public static IInventoryState GetInstance
        {
            get
            {
                if(instance == null)
                    instance  = new InitialzedInventoryState(null);
                return instance;
            }
        }

        public override int ReturnToClient() => 0;
    }

 
}
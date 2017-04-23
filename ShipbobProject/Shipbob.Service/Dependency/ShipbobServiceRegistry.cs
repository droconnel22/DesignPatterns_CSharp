using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Service.CacheController;
using Shipbob.Service.Configuration;
using Shipbob.Service.Factory;
using Shipbob.Service.ServiceBuilder;
using Shipbob.Service.ServiceStrategies;
using StructureMap.Configuration.DSL;

namespace Shipbob.Service.Dependency
{
    public class ShipbobServiceRegistry :Registry
    {
        public ShipbobServiceRegistry()
        {
            //Configuration.
            this.For<IServiceConfiguration>().Singleton().Use<ServiceConfiguration>();
           
            //Services
            this.For<IInventoryServiceBuilder>().Singleton().Use<InventoryServiceBuilder>();
        

            this.For<IInventoryServiceStrategy>().Singleton().Use<DefaultInventoryStrategy>();
            
        }
    }
}

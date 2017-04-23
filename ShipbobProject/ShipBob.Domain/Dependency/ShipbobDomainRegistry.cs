using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Service.Service.Order;
using ShipBob.Domain.Manager;
using StructureMap.Configuration.DSL;

namespace ShipBob.Domain.Dependency
{
    public class ShipbobDomainRegistry : Registry
    {
        public ShipbobDomainRegistry()
        {
            this.For<IManager>().Singleton().Use<Manager.Manager>();
            this.For<IOrderService>().Singleton().Use<OrderService>();
        }
    }
}

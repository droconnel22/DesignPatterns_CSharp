using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Service.Dependency;
using StructureMap;

namespace ShipBob.Domain.Dependency
{
    public static class ShipbobDomainBootstrapper
    {
        public static IContainer BootStrap()
        {
            ObjectFactory.Initialize(
                x =>
                {
                    x.AddRegistry(new ShipbobDomainRegistry());
                });
            return ObjectFactory.Container;
        }
    }
}

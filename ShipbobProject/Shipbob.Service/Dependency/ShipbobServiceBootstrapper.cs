using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Data.Dependency;
using StructureMap;

namespace Shipbob.Service.Dependency
{
   public static class ShipbobServiceBootstrapper
    {
        public static IContainer BootStrap()
        {
            ObjectFactory.Initialize(
                x =>
                {
                    x.AddRegistry(new ShipbobServiceRegistry());
                });
            return ObjectFactory.Container;
        }
    }
}

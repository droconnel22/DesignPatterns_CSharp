using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace Shipbob.Data.Dependency
{
   public static class ShipbobDataBootstrapper
    {
        public static IContainer BootStrap()
        {
            ObjectFactory.Initialize(
                x =>
                {
                    x.AddRegistry(new ShipbobDataRegistry());
                });
            return ObjectFactory.Container;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Data.Entities;
using Shipbob.Data.Entities.Utility;

namespace Shipbob.Test.Utility
{
   internal static class ShipbobTestUtility
   {
       public static OrderEntity GetValidOrderEntity() => new OrderEntity()
       {
           OrderId = 0,
           TrackingId = "Demo Id",
           CreatedOrder = DateTime.Now,
           AddressEntity = new AddressEntity()
           {
               AddressId = 0,
               City = "Chicago",
               Name = "Dennis",
               PostalCode = "60661",
               State = "IL",
               Street = "Jefferson"
           },
           Items = new List<ItemEntity>()
           {
               new ItemEntity()
               {
                   IsSold = true,
                   ItemColor = ItemColors.White,
                   ItemType = ItemTypes.Hat,
                   ItemId = 0
               }
           }
       };

       public static ItemEntity GetValidItemEntity => new ItemEntity()
       {
           IsSold = true,
           ItemColor = ItemColors.White,
           ItemType = ItemTypes.Hat,
           ItemId = 0
       };
   }
}

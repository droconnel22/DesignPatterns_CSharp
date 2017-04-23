using System.Collections.Generic;
using Shipbob.Data.Entities.Utility;

namespace Shipbob.Data.Entities
{
    public interface IItemEntity
    {
        ItemColors ItemColor { get; set; }
        int ItemId { get; set; }
        ItemTypes ItemType { get; set; }

        bool IsSold { get; set; }
        ICollection<OrderEntity> Orders { get; set; }
    }
}
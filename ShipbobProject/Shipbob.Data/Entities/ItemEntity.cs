using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Data.Entities.Utility;

namespace Shipbob.Data.Entities
{
    [Table("Items")]
    public class ItemEntity : IItemEntity
    {
        public ItemEntity()
        {
            this.Orders = new List<OrderEntity>();
        }

        [Key]
        public  int ItemId { get; set; }

        [Required]
        public ItemColors ItemColor { get; set; }

        [Required]
        public ItemTypes ItemType { get; set; }       

        public virtual ICollection<OrderEntity> Orders { get; set; }

        public bool IsSold { get; set; }        
    }
}

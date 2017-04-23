using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipbob.Data.Entities
{
    [Table("Orders")]
    public class OrderEntity
    {
        public OrderEntity()
        {
            //Prevent Potential Null Reference For Client.
            this.Items = new List<ItemEntity>();
        }

        [Key]
        public int OrderId { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "ORder Requires a Tracking Id")]
        [DataType(DataType.Text)]
        public string TrackingId { get; set; }

        [Required]        
        public DateTime? CreatedOrder { get; set; }

       
        public AddressEntity AddressEntity { get; set; }

        
        public virtual ICollection<ItemEntity> Items { get; set; }
    }
}

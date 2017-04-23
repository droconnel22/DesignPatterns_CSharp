using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShipBob.Domain.ViewModels
{
    public class OrderViewModel 
    {
        public OrderViewModel()
        {
            this.Items = new List<ItemViewModel>();
        }

        [Required]
        [MaxLength(100, ErrorMessage = "Order Requires a Tracking Id")]
        [DataType(DataType.Text)]
        public string TrackingId { get; set; }

        [Required]
        public AddressViewModel OrderAddress { get; set; }

        [Required]
        public IEnumerable<ItemViewModel> Items { get; set; }

    }
}
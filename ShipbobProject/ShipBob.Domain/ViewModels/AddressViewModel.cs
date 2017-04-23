using System.ComponentModel.DataAnnotations;

namespace ShipBob.Domain.ViewModels
{
    public class AddressViewModel
    {
        [Required]
        public string AddressName { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }

    }
}
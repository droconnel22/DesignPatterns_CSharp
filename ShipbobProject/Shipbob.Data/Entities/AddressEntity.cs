using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Shipbob.Data.Entities
{
    //  AddressEntity {Name, Street AddressEntity, City, State, ZipCode}
    
    [Table("Addresses")]
    public class AddressEntity
    {
        public AddressEntity()
        {

        }

        [Key]
        public  int AddressId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "AddressEntity name is too long. 100 Max.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Street name is too long. 100 Max.")]
        [DataType(DataType.Text)]
        public string Street { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "City name is too long. 100 Max.")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "State Abbreviation is too long. 2 Max.")]
        [DataType(DataType.Text)]
        public string State { get; set; }


        [Required]
        [MaxLength(20, ErrorMessage = "State Abbreviation is too long. 2 Max.")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

    }
}

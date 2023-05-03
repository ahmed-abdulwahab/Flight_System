using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalV4.Models
{
    public class Hotel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Hotel Name !! ")]
        [MaxLength(10, ErrorMessage = "Too long Name ")]
        public string Name { get; set; }
        public byte[] ?Image { get; set; }

        [Required(ErrorMessage = "Please Enter Location !! ")]
        [MaxLength(10, ErrorMessage = "Too long Location Name ")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please Enter Price of Room !! ")]
        public decimal PriceOfRoom { get; set; }

        [Required(ErrorMessage = "Please Enter Number of Rooms in Hotel !! ")]
        public int NumberOfRooms { get; set; }

        [ForeignKey("City")]
        public int City_id { get; set; }
        public virtual City City { get; set; }





    }
}

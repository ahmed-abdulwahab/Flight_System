using System.ComponentModel.DataAnnotations;

namespace FinalV4.Models
{
    public class City
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter City Name ! ")]
        [MaxLength(20, ErrorMessage = "Too long Name ")]
        public string Name { get; set; }

        public virtual List<Flight> DepartingFlights { get; set; }
        public virtual List<Flight> ArrivingFlights { get; set; }
        public virtual List<Hotel> Hotels { get; set; }
    }
}

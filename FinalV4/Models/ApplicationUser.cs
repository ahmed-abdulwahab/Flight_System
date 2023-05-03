using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalV4.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string? Fname { get; set; }
        public string? Lname { get; set; }
        [ForeignKey("Hotel")]
        public int? HotelId { get; set; }
        public int Age { get; set; }
        public byte[]? Image { get; set; }
        public string? Location { get; set; }
        public virtual Hotel? Hotel { get; set; }

        public virtual List<Flight>? Flights { get; set; }
    }
}

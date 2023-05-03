using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalV4.Models
{
	public enum Flight_Type { Return, OneWay }
	public enum Flight_Class { Economy, Business, VIP }
	public class Flight
    {
        [Key]
        //[Required]
        public int Id { get; set; }

		[DataType(DataType.Date)]
		public DateTime DateFrom { get; set; }
		[DataType(DataType.Date)]
		public Nullable<DateTime> DateTo { get; set; }

		[DataType(DataType.Currency)]
		[Range(typeof(decimal), "0", "79228162514264337593543950335")]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "Please Enter Number of seats")]
		[Range(typeof(int), "10", "100")]
		public int NumberOfSeats { get; set; }

		[ForeignKey("Company")]
        public string? Comp_id { get; set; }
        public virtual ApplicationUser Company { get; set; }

		[Required(ErrorMessage = "Please Choose Type of your Flight : ( One Way - Two Way ) ")]
		public Flight_Type flight_Type { get; set; }
		[Required(ErrorMessage = "Please Choose Class of your Flight : ( One Way - Two Way ) ")]

		public Flight_Class flight_Class { get; set; }

		[ForeignKey("DepartureCity")]
        public int DepartureCityId { get; set; }
        public virtual City? DepartureCity { get; set; }


        [ForeignKey("ArrivalCity")]
        public int ArrivalCityId { get; set; }
        public virtual City? ArrivalCity { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalV4.Models
{
	public enum Reserve_seats { Front, Back, Next_To_window }

	public class BookTicket
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public String User_id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Flight")]
        public int Flight_id { get; set; }
        public virtual Flight Flight { get; set; }

		[DataType(DataType.Currency)]
		public decimal TotalPrice { get; set; }
        public int NumberOfTicket { get; set; }
        public string Description { get; set; }
        public Reserve_seats reserve_Seats { get; set; }

	}
}

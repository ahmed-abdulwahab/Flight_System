using System.ComponentModel.DataAnnotations;

namespace FinalV4.ViewModel
{
    public class CompanyRoleViewModel
    {
        [MaxLength(10)]
        [Required]

        public string Name { get; set; }
        //  public byte[]? Image { get; set; }
        [Required(ErrorMessage = "Please Enter Location !! ")]
        [MaxLength(10, ErrorMessage = "Too long Location Name ")]
        public string Location { get; set; }

        [Required]
        [RegularExpression(@"^01\d{9}$", ErrorMessage = "Invalid mobile number format.")]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password not mached")]
        public string Confirm_Password { get; set; }
    }
}

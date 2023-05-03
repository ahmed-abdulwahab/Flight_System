using System.ComponentModel.DataAnnotations;

namespace FinalV4.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}

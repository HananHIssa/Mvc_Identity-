using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Models.ViewModel
{
    public class RegisterViewModelcs
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [MaxLength(234)]
        [Required]
        public string password { get; set; } = null!;
        [DataType(DataType.Password)]
        [MaxLength(234)]
        [Required]
        [Compare("password")]
        public string ConfirmPassword { get; set; } = null!;
        public string phoneNumber { get; set; } = null!;
    }
}

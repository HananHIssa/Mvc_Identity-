using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Models.ViewModel
{
    public class LogInViewModelcs
    {
        [EmailAddress]
        public string email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string password { get; set; } = null!;
        public bool remberMe { get; set; }
    }
}

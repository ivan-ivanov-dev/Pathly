using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Authentication
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = ErrorMessages.EmailIsRequired)]
        [EmailAddress(ErrorMessage = ErrorMessages.InvalidEmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = ErrorMessages.PasswordIsRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}

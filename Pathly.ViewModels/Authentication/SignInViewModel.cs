using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Authentication
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = ErrorMessages.EmailIsRequired)]
        [EmailAddress(ErrorMessage = ErrorMessages.InvalidEmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.PasswordIsRequired)]
        [DataType(DataType.Password)]
        [MinLength(ValidationConstants.MinPasswordLength, ErrorMessage = ErrorMessages.PasswordMustBeAtLeast6CharactersLong)]
        [MaxLength(ValidationConstants.MaxPasswordLength, ErrorMessage = ErrorMessages.PasswordCannotExceed100Characters)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.PasswordMustBeConfirmed)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ErrorMessages.PasswordsDoNotMatch)]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.UserNameIsRequired)]
        [MinLength(ValidationConstants.MinUserNameLength, ErrorMessage = ErrorMessages.UserNameMustBeAtLeast3CharactersLong)]
        [MaxLength(ValidationConstants.MaxUserNameLength, ErrorMessage = ErrorMessages.UserNameCannotExceed50Characters)]
        public string UserName { get; set; } = null!;
    }
}

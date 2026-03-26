using Pathly.GCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.ViewModels.Settings
{
    public class SettingsViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string? CurrentPassword { get; set; }

        [MinLength(ValidationConstants.MinPasswordLength, ErrorMessage = ErrorMessages.PasswordMustBeAtLeast6CharactersLong)]
        [MaxLength(ValidationConstants.MaxPasswordLength, ErrorMessage = ErrorMessages.PasswordCannotExceed100Characters)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = ErrorMessages.PasswordsDoNotMatch)]
        public string? ConfirmPassword { get; set; }
    }
}

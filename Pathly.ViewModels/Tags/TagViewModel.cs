using Pathly.GCommon;
using System.ComponentModel.DataAnnotations;

namespace Pathly.ViewModels.Tags
{
    public class TagViewModel
    {
        [Required(ErrorMessage = ErrorMessages.TagNameIsRequired)]
        [StringLength(ValidationConstants.MaxTagNameLength, ErrorMessage = ErrorMessages.TagNameCannotExceed30Characters)]
        public string Name { get; set; } = null!;
    }
}

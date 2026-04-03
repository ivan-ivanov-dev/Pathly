using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.GCommon
{
    public class ErrorMessages
    {
        // User registration and login
        public const string EmailIsRequired = "Email is required.";
        public const string InvalidEmailAddress = "Invalid email address.";

        // Password validation
        public const string PasswordIsRequired = "Password is required.";
        public const string PasswordMustBeAtLeast6CharactersLong = "Password must be at least 6 characters long.";
        public const string PasswordCannotExceed100Characters = "Password cannot exceed 100 characters.";
        public const string PasswordMustBeConfirmed = "Please confirm your password.";
        public const string PasswordsDoNotMatch = "Passwords do not match.";

        // User profile
        public const string UserNameIsRequired = "Username is required.";
        public const string UserNameMustBeAtLeast3CharactersLong = "Username must be at least 3 characters long.";
        public const string UserNameCannotExceed50Characters = "Username cannot exceed 50 characters.";

        // Goal validation
        public const string GoalTitleIsRequired = "Goal Title is required.";
        public const string GoalTitleCannotExceed50Characters = "Title cannot exceed 50 characters.";
        public const string GoalShortDescriptionCannotExceed200Characters = "Short goal description cannot exceed 200 characters.";
        public const string GoalLongDescriptionCannotExceed1500Characters = "Long goal description cannot exceed 1500 characters.";

        // Roadmap + action validation
        public const string ActionTitleCannotExceed100Characters = "Title cannot exceed 100 characters.";
        public const string ActionResourcesCannotExceed500Characters = "Description cannot exceed 500 characters.";

        public const string RoadmapDescriptionCannotExceed2000Characters = "This description cannot exceed 2000 characters.";

        // Tag validation
        public const string TagNameIsRequired = "Tag name is required.";
        public const string TagNameCannotExceed30Characters = "Tag name cannot exceed 30 characters.";

        // Task validation
        public const string TaskItemTitleCannotExceed100Characters = "Task title cannot exceed 100 characters.";
        public const string TaskItemDescriptionCannotExceed500Characters = "Task description cannot exceed 500 characters.";

        // General validation
        public const string TitleIsRequired = "Title is required.";

        // Event validation
        public const string EndDateMustBeAfterStartDate = "End date must be after start date.";
        public const string StartDateCannotBeInThePast = "Start date cannot be in the past.";
        public const string SelectedTaskDoesNotExist = "The selected task does not exist.";
        public const string SelectedGoalDoesNotExist = "The selected goal does not exist.";
        public const string EventNotFoundOrAccessDenied = "Event not found or access denied.";
        public const string NoEventsFound = "No events found.";

        // This is a general message template for required fields, max length, and min length validations.It is used in Event Entities and ViewModels only.
        public const string RequiredField = "The {0} field is required.";
        public const string MaxLength = "The {0} cannot exceed {1} characters.";
        public const string MinLength = "The {0} must be at least {1} characters.";
        public const string InvalidColor = "Please provide a valid Hex color code.";
    }
}

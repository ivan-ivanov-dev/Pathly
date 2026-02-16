using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathly.GCommon
{
    public class ErrorMessages
    {
        public const string EmailIsRequired = "Email is required.";
        public const string InvalidEmailAddress = "Invalid email address.";

        public const string PasswordIsRequired = "Password is required.";
        public const string PasswordMustBeAtLeast6CharactersLong = "Password must be at least 6 characters long.";
        public const string PasswordCannotExceed100Characters = "Password cannot exceed 100 characters.";
        public const string PasswordMustBeConfirmed = "Please confirm your password.";
        public const string PasswordsDoNotMatch = "Passwords do not match.";

        public const string UserNameIsRequired = "Username is required.";
        public const string UserNameMustBeAtLeast3CharactersLong = "Username must be at least 3 characters long.";
        public const string UserNameCannotExceed50Characters = "Username cannot exceed 50 characters.";

        public const string GoalTitleIsRequired = "Goal Title is required.";
        public const string GoalTitleCannotExceed50Characters = "Title cannot exceed 50 characters.";
        public const string GoalShortDescriptionCannotExceed200Characters = "Short goal description cannot exceed 200 characters.";
        public const string GoalLongDescriptionCannotExceed1500Characters = "Long goal description cannot exceed 1500 characters.";

        public const string ActionTitleCannotExceed100Characters = "Title cannot exceed 100 characters.";
        public const string ActionResourcesCannotExceed500Characters = "Description cannot exceed 500 characters.";

        public const string RoadmapDescriptionCannotExceed2000Characters = "This description cannot exceed 2000 characters.";

        public const string TagNameIsRequired = "Tag name is required.";
        public const string TagNameCannotExceed30Characters = "Tag name cannot exceed 30 characters.";

        public const string TaskItemTitleCannotExceed100Characters = "Task title cannot exceed 100 characters.";
        public const string TaskItemDescriptionCannotExceed500Characters = "Task description cannot exceed 500 characters.";

        public const string TitleIsRequired = "Title is required.";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYF.WebAPI.Models.Utilities
{
    public static class ErrorMessages
    {
        public const string MESSAGE_FOR_NOT_MATCHED_PASSWORD =
            "Invalid password (Minimum 6 characters and at least 1 Uppercase Alphabet, 1 Lowercase Alphabet and 1 Number)";
        public const string MESSAGE_FOR_NOT_MATCHED_USERNAME = "The Username must contains between 2 and 15 only letters and digits";
        public const string MESSAGE_FOR_NOT_MATCHED_EMAIL = "The passed email is invalid.";
        public const string MESSAGE_FOR_NOT_MATCHED_NAME = "The name must contains between 2 and 15 only letter characters";
        public const string MESSAGE_FOR_MISSING_REQUIRED_FIELD = "This field is required.";
        public const string MESSAGE_FOR_CONFIRM_PASSWORD = "The password and confirmation password do not match.";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYF.WebAPI.Models.Utilities
{
    public static class ErrorMessages
    {
        /////////////////////////
        // USER ERROR MESSAGES //
        /////////////////////////
        
        public const string MESSAGE_FOR_NOT_MATCHED_PASSWORD =
            "Invalid password (Minimum 6 characters and at least 1 Uppercase Alphabet, 1 Lowercase Alphabet and 1 Number).";
        public const string MESSAGE_FOR_NOT_MATCHED_USERNAME = "The Username must contains between 2 and 15 characters only letters and digits.";
        public const string MESSAGE_FOR_NOT_MATCHED_EMAIL = "The passed email is invalid.";
        public const string MESSAGE_FOR_NOT_MATCHED_NAME = "The name must contains between 2 and 15 characters only letters.";
        public const string MESSAGE_FOR_NOT_MATCHED_BUSINESS_NAME = "The Business Name must be between 2 and 30 characters with only letters, digits and '&' .";
        public const string MESSAGE_FOR_NOT_MATCHED_PHONE = "The phone number is invalid.";
        public const string MESSAGE_FOR_NOT_MATCHED_BULSTAT_ID_NUMBER = "The Bulstat Id Number can contains between 13 and 15 only digits.";
        public const string MESSAGE_FOR_MISSING_REQUIRED_FIELD = "This field is required.";
        public const string MESSAGE_FOR_CONFIRM_PASSWORD = "The password and confirmation password do not match.";   
    }
}

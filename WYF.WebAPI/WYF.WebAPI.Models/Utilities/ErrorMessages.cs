using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYF.WebAPI.Models.Utilities
{
    public static class ErrorMessages
    {
        
        ///////////////////////////
        // COMMON ERROR MESSAGES //
        ///////////////////////////

        public const string NOT_MATCHED_CITY_NAME = "The City Name must be between 2 and 20 only letters.";

        /////////////////////////
        // USER ERROR MESSAGES //
        /////////////////////////

        public const string NOT_MATCHED_PASSWORD =
            "Invalid password (Minimum 6 characters and at least 1 Uppercase Alphabet, 1 Lowercase Alphabet and 1 Number).";
        public const string NOT_MATCHED_USERNAME = "The Username must contains between 2 and 15 characters only letters and digits.";
        public const string NOT_MATCHED_EMAIL = "The passed email is invalid.";
        public const string NOT_MATCHED_NAME = "The name must contains between 2 and 15 characters only letters.";
        public const string NOT_MATCHED_BUSINESS_NAME = "The Business Name must be between 2 and 30 characters with only letters, digits and '&' .";
        public const string NOT_MATCHED_PHONE = "The phone number is invalid.";
        public const string NOT_MATCHED_BULSTAT_ID_NUMBER = "The Bulstat Id Number can contains between 13 and 15 only digits.";
        public const string MISSING_REQUIRED_FIELD = "This field is required.";
        public const string CONFIRM_PASSWORD = "The password and confirmation password do not match.";
        public const string EMPLOYEE_EXPERIENCE = "Experience can contain maximum 500 characters.";
        public const string MOTIVATIONAL_LETTER = "Motivational letter can contain maximum 500 characters.";

        ////////////////////////
        // JOB ERROR MESSAGES //
        ////////////////////////

        public const string JOB_POSTING_TITLE = "The Job Title must be between 3 and 35 characters with only letters, digits and '&' .";
        public const string JOB_DESCRIPTION = "Job Description can contain maximum 1000 characters.";
        public const string NOT_MATCHED_INDUSTRY_NAME = "The Industry Name must be between 2 and 30 characters with only letters and '&' .";
    }
}

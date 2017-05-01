using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYF.WebAPI.Models.Utilities
{
    public static class Constants
    {
        //////////
        // URLS //
        //////////
        
        public const string WYF_CLIENT_APP_ORIGIN_URL = "http://localhost:3000";

        ////////////////////
        // REGEX PATTERNS //
        ////////////////////
        
        public const string EMAIL_REGEX_PATTERN = "^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$";
        public const string PASSWORD_REGEX_PATTERN = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{6,}$";
        public const string NAME_REGEX_PATTERN = "^[A-Za-z]{2,15}$";
        public const string BUSINESS_NAME_REGEX_PATTERN = "^[A-Za-z&\\s0-9]{2,30}$";
        public const string USERNAME_REGEX_PATTERN = "^[a-zA-Z0-9]{2,15}$";
        public const string PHONE_REGEX_PATTERN = "^[0-9]{10}$";
        public const string BULSTAT_ID_NUMBER_REGEX_PATTERN = "^[0-9]{13,15}$";

    }
}

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
        // USER CONSTANTS //
        ////////////////////

        public const int EMPLOYEE_EXPERIANCE_MAX_LENGTH = 500;
        public const int MOTIVATIONAL_LETTER_MAX_LENGTH = 500;

        ///////////////////
        // JOB CONSTANTS //
        ///////////////////

        public const int JOB_DESCRIPTION_MAX_LENGTH = 1000;
    }
}

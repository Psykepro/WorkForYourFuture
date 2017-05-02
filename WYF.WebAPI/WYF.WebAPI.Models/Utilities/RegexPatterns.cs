﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYF.WebAPI.Models.Utilities
{
    public static class RegexPatterns
    {
        
        /////////////////////
        // COMMON PATTERNS //
        /////////////////////

        public const string CITY_NAME = "^[a-zA-Z]{2,20}$";
        

        ///////////////////
        // USER PATTERNS //
        ///////////////////

        public const string EMAIL = "^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$";
        public const string PASSWORD = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{6,}$";
        public const string NAME = "^[A-Za-z]{2,15}$";
        public const string BUSINESS_NAME = "^[A-Za-z&\\s0-9]{2,30}$";
        public const string USERNAME = "^[a-zA-Z0-9]{2,15}$";
        public const string PHONE = "^[0-9]{10}$";
        public const string BULSTAT_ID_NUMBER = "^[0-9]{13,15}$";

        //////////////////
        // JOB PATTERNS //
        //////////////////

        public const string JOB_TITLE = "^[A-Za-z&\\s0-9]{3,35}$";
        public const string INDUSTRY_NAME = "^[a-zA-Z&]{2,30}$";



    }
}

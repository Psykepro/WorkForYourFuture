﻿using System;
using System.ComponentModel.DataAnnotations;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.BindingModels.User
{
    public class RegisterEmployeeBindingModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.USERNAME, ErrorMessage = ErrorMessages.NOT_MATCHED_USERNAME)]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.EMAIL, ErrorMessage = ErrorMessages.NOT_MATCHED_EMAIL)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(pattern: RegexPatterns.PASSWORD, ErrorMessage = ErrorMessages.NOT_MATCHED_PASSWORD)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [Compare("Password", ErrorMessage = ErrorMessages.CONFIRM_PASSWORD)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.NAME, ErrorMessage = ErrorMessages.NOT_MATCHED_NAME)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.NAME, ErrorMessage = ErrorMessages.NOT_MATCHED_NAME)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        public DateTime DateOfBirth { get; set; }
    }
}

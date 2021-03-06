﻿using System.ComponentModel.DataAnnotations;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.EntityModels.Common
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.CITY_NAME, ErrorMessage = ErrorMessages.NOT_MATCHED_CITY_NAME)]
        [DataType("VARCHAR(20)")]
        public string Name { get; set; }
    }
}

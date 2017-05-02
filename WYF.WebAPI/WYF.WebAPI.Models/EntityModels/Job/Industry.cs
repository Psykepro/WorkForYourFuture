using System.ComponentModel.DataAnnotations;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.EntityModels.Job
{
    public class Industry
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.INDUSTRY_NAME, ErrorMessage = ErrorMessages.NOT_MATCHED_INDUSTRY_NAME)]
        [DataType("VARCHAR(30)")]
        public string Name { get; set; }
    }
}

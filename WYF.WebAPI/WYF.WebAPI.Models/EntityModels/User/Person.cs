using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WYF.WebAPI.Models.Enums.User;
using WYF.WebAPI.Models.Utilities;

namespace WYF.WebAPI.Models.EntityModels.User
{
    /// <summary>
    ///     This class will be used only to reuse the common properties between Employee and Employer.
    /// </summary>
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.NAME, ErrorMessage = ErrorMessages.NOT_MATCHED_NAME)]
        [DataType("VARCHAR(15)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [RegularExpression(pattern: RegexPatterns.NAME, ErrorMessage = ErrorMessages.NOT_MATCHED_NAME)]
        [DataType("VARCHAR(15)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = ErrorMessages.MISSING_REQUIRED_FIELD)]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string UserId { get; set; }

        [ForeignKey(name: "UserId")]
        public virtual User User { get; set; }
    }
}

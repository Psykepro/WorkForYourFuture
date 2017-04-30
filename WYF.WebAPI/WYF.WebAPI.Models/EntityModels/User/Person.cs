using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WYF.WebAPI.Models.Enums.User;

namespace WYF.WebAPI.Models.EntityModels.User
{
    /// <summary>
    ///     This class will be used only to reuse the common properties between Employee and Employer.
    /// </summary>
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(length: 2, ErrorMessage = "The allowed minimum length of FirstName is 2 characters.")]
        [MaxLength(length: 15, ErrorMessage = "The allowed maximum length of FirstName is 15 characters.")]
        [RegularExpression(pattern: "^[A-Za-z]+$", ErrorMessage = "FirstName can contains only letters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(length: 2, ErrorMessage = "The allowed minimum length of LastName is 2 characters.")]
        [MaxLength(length: 15, ErrorMessage = "The allowed maximum length of LastName is 15 characters.")]
        [RegularExpression(pattern: "^[A-Za-z]+$", ErrorMessage = "LastName can contains only letters.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string UserId { get; set; }

        [ForeignKey(name: "UserId")]
        public virtual User User { get; set; }
    }
}

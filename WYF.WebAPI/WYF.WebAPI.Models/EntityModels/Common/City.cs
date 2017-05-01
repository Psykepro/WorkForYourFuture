using System.ComponentModel.DataAnnotations;

namespace WYF.WebAPI.Models.EntityModels.Job
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The allowed minimum length of the City is 2 characters.")]
        public string Name { get; set; }
    }
}

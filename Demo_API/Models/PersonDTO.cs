using System.ComponentModel.DataAnnotations;

namespace Demo_API.Models
{
    public class PersonDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
    }
}

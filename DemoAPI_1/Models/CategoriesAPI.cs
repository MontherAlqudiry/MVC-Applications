using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DemoAPI_1.Models
{
    public class CategoriesAPI
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(30)]
        [Required]
        public String Name { get; set; }
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Demo.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(30)]
        [Required]
        public String? Name { get; set; }

        [Range(1,100,ErrorMessage ="Display Order must be between 1-100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        [AllowNull]
        [DisplayName("Discription")]
        public string Disc { get; set; }

        [DisplayName("Image Name")]
        public string? ImageName {  get; set; }

        [DisplayName("Upload Image")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }





    }
}

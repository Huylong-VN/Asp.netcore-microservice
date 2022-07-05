using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Product
{
    public abstract class CreateOrUpdateProductDto
    {
        [Required]
        [MaxLength(250, ErrorMessage = "Maximum length for Product Name is 250 characters.")]
        public string? Name { set; get; }
        [MaxLength(255, ErrorMessage = "Maximum length for Product Summary is 255 characters.")]
        public string? Summary { set; get; }
        public string? Description { set; get; }
        public decimal? Price { set; get; }
    }
}

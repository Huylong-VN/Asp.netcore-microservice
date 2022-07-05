using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Product
{
    public class CreateProductDto : CreateOrUpdateProductDto
    {
        [Required]
        public string? No { set; get; }
    }
}

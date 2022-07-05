using Contracts.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API.Entities
{
    public class CatalogProduct : EntityAuditBase<long>
    {
        [Required]
        [Column(TypeName = "Varchar(150)")]
        public string? No { set; get; }

        [Required]
        [Column(TypeName = "Varchar(150)")]
        public string? Name { set; get; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Summary { get; set; }

        [Column(TypeName = "text")]
        public string? Description { set; get; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? Price { get; set; }

    }
}

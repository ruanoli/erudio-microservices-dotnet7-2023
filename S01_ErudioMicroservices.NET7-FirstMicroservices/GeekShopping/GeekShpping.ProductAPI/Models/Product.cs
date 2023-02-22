using GeekShpping.ProductAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShpping.ProductAPI.Models
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [StringLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo preço é obrigatório!")]
        [StringLength(150)]
        [Range(1,10000)]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? CategoryName { get; set; }

        [StringLength(255)]
        public string? ImageURL { get; set;}
    }
}

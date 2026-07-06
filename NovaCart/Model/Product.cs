using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaCart.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(150, ErrorMessage = "Product name cannot exceed 150 characters.")]
        public string Name { get; set; } = string.Empty;
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be between 0.01 and 999,999.99")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }
        [ForeignKey(nameof(Category))]
        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
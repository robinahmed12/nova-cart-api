using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaCart.Model
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [ForeignKey(nameof(Order))]
        [Required(ErrorMessage = "OrderId is required.")]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        [ForeignKey(nameof(Product))]
        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 10000, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Unit price is required.")]
        [Range(0.01, 999999.99, ErrorMessage = "Unit price must be between 0.01 and 999,999.99")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal UnitPrice { get; set; }
    }
}
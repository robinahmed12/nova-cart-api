using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaCart.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; }
        [ForeignKey(nameof(Customer))]
        [Required(ErrorMessage = "CustomerId is required.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Order amount is required.")]
        [Range(0.0, 99999999.99, ErrorMessage = "Order amount must be positive.")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal OrderAmount { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
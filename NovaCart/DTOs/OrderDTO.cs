using System.ComponentModel.DataAnnotations;

namespace NovaCart.DTOs
{
    public class OrderDTO
    {
        public int? OrderId { get; set; }
        [Required(ErrorMessage = "Order Date is required.")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "CustomerId is required.")]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        [Required(ErrorMessage = "Order Amount is required.")]
        [Range(0.0, 99999999.99, ErrorMessage = "Order Amount must be positive.")]
        public decimal OrderAmount { get; set; }
        [Required(ErrorMessage = "Order Items are required.")]
        public List<OrderItemDTO> OrderItems { get; set; } = new();
    }
}

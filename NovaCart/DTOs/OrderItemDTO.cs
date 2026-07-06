using System.ComponentModel.DataAnnotations;

namespace NovaCart.DTOs
{
    public class OrderItemDTO
    {
        public int? OrderItemId { get; set; }
        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 10000, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Unit Price is required.")]
        [Range(0.01, 999999.99, ErrorMessage = "Unit Price must be between 0.01 and 999,999.99.")]
        public decimal UnitPrice { get; set; }
    }
}

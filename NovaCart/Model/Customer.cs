using System.ComponentModel.DataAnnotations;

namespace NovaCart.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(200, ErrorMessage = "Full name cannot exceed 200 characters.")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = null!;
        public ICollection<Order>? Orders { get; set; }
    }
}

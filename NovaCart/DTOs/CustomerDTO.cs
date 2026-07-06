using System.ComponentModel.DataAnnotations;

namespace NovaCart.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(200, ErrorMessage = "Full Name cannot exceed 200 characters.")]
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
        public string Email { get; set; } = null!;
    }
}

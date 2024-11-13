using System.ComponentModel.DataAnnotations;

namespace BorrowLend.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Item name")]
        [Required(ErrorMessage = "Item name is required")]
        [StringLength(100, ErrorMessage = "Item name cannot be longer than 100 characters")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Borrower is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Borrower name must be between 2 and 50 characters")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Borrower name can only contain letters")]
        public string Borrower { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[A-Za-z0-9._]+@[A-Za-z]+\.[A-Za-z]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Phone number must be exactly 9 digits")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lender is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lender name must be between 2 and 50 characters")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Lender name can only contain letters")]
        public string Lender { get; set; }
    }
}

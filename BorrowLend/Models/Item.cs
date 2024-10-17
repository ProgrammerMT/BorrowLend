using System.ComponentModel.DataAnnotations;

namespace BorrowLend.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Item name")]
        [Required(ErrorMessage = "Item name is required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Borrower is required")]
        public string Borrower { get; set; }

        [Required(ErrorMessage = "Lender is required")]
        public string Lender { get; set; }
    }
}

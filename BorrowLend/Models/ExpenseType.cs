using System.ComponentModel.DataAnnotations;

namespace BorrowLend.Models
{
    public class ExpenseType
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Expense type name is required.")]
        public string ExpenseTypeName { get; set; }
    }
}

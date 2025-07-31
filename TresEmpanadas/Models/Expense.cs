using System.ComponentModel.DataAnnotations;

namespace TresEmpanadas.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string? Description { get; set; }

        // User relationship
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

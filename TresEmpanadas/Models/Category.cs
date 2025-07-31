using System.ComponentModel.DataAnnotations;

namespace TresEmpanadas.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        // User relationship
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

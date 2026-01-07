using System.ComponentModel.DataAnnotations;

namespace Finances_API.Controllers.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}

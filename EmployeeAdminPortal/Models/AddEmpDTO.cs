using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models
{
    public class AddEmpDTO
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }

        [Required]
        [MinLength(10,ErrorMessage ="Error message")]
        [MaxLength(10)]
        public string? Phone { get; set; }
        [Range(1000,999999)]
        public decimal Salary { get; set; }
    }
}

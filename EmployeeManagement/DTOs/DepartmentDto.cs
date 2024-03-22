using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(50, ErrorMessage = "Department name must be at most 50 characters long.")]
        [RegularExpression(@"^[^\d\W]+$", ErrorMessage = "Name cannot contain digits or special characters.")]
        public string DepartmentName { get; set; }
    }
}

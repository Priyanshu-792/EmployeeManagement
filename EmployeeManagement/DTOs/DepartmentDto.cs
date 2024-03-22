using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DTOs
{
    public class DepartmentDTO
    {   //Proper Validations.
        public int Id { get; set; }
        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(50, ErrorMessage = "Department name must be at most 50 characters long.")]
        public string DepartmentName { get; set; }
    }
}

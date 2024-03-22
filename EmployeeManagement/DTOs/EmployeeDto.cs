using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Range(21, 100, ErrorMessage = "Age must be between 21 and 100")]  //Proper Validations.
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
    }
}

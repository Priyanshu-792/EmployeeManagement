using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(50)]
        [RegularExpression(@"^[^\d\W]+$", ErrorMessage = "Name cannot contain digits or special characters.")]
        public string DepartmentName { get; set; }

    }
}

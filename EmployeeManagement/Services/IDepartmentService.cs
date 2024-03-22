using EmployeeManagement.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> GetDepartmentByIdAsync(int id);
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
        Task AddDepartmentAsync(DepartmentDTO department);
        Task UpdateDepartmentAsync(int id, DepartmentDTO department);
        Task DeleteDepartmentAsync(int id);
    }
}

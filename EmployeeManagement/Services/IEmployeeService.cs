using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.DTOs;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(EmployeeDTO employee);
        Task UpdateEmployeeAsync(int id, EmployeeDTO employee);
        Task DeleteEmployeeAsync(int id);
    }
}

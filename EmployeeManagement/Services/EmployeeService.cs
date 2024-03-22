using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            return employee != null ? _mapper.Map<EmployeeDTO>(employee) : null;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task AddEmployeeAsync(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeDTO employeeDto)
        {
            var existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (existingEmployee == null)
                return; // No action if employee not found

            _mapper.Map(employeeDto, existingEmployee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return; // No action if employee not found

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}

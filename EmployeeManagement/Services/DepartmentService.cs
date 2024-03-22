using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            return department != null ? _mapper.Map<DepartmentDTO>(department) : null;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _dbContext.Departments.ToListAsync();
            return _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
        }

        public async Task AddDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto); // Mapping DTO to entity
            _dbContext.Departments.Add(department);
            await _dbContext.SaveChangesAsync(); // Use async method to save changes
        }



        public async Task UpdateDepartmentAsync(int id, DepartmentDTO departmentDto)
        {
            var existingDepartment = await _dbContext.Departments.FindAsync(id);
            if (existingDepartment == null)
                throw new NotFoundException("Department not found");

            _mapper.Map(departmentDto, existingDepartment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            if (department == null)
                throw new NotFoundException("Department not found");

            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}

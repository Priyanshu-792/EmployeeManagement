using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.DTOs;
using EmployeeManagement.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        {  // Retrieve all employees from the service
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeDTO employeeDto)

        {// Return bad request if model state is invalid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _employeeService.AddEmployeeAsync(employeeDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the employee: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _employeeService.UpdateEmployeeAsync(id, employeeDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the employee: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the employee: {ex.Message}");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.DTOs;
using EmployeeManagement.Services;
using System;


namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService; // injection
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _departmentService.AddDepartmentAsync(departmentDTO); // Change to async method

            return Ok("Department added successfully");
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, [FromBody] DepartmentDTO departmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _departmentService.UpdateDepartmentAsync(id, departmentDto);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the department: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            try
            {
                await _departmentService.DeleteDepartmentAsync(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); // Return not found if department is not found
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the department: {ex.Message}");
            }
        }
    }
}

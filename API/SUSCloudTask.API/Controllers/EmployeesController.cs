using Microsoft.AspNetCore.Mvc;
using SUSCloudTask.BLL.DTOs.Employee;
using SUSCloudTask.BLL.Services.EmployeeService;

namespace SUSCloudTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetEmployeesAsync();

            return Ok(new { Message = "Success", Data = employees });
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);

            if (employee == null)
                return BadRequest(new { Message = "Employee not found" });

            return Ok(new { Message = "Success", Data = employee });
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                var res = await _employeeService.AddEmployeeAsync(employee);

                if (res)
                    return Ok(new { Message = "Success" });
                else
                    return BadRequest(new { Message = "Failed to add employee." });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();

            return Ok(new { Message = errors });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EditEmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                var res = await _employeeService.UpdateEmployeeAsync(employee);

                if (res)
                    return Ok(new { Message = "Success" });
                else
                    return BadRequest(new { Message = "Failed to update employee." });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();

            return Ok(new { Message = errors });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _employeeService.DeleteEmployeeAsync(id);

            if (res)
                return Ok(new { Message = "Success" });
            else
                return BadRequest(new { Message = "Fail", error = "ID not exists" });
        }
    }
}

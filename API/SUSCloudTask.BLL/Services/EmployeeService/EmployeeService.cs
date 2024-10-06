using SUSCloudTask.BLL.DTOs.Employee;
using SUSCloudTask.DAL.Entities;
using SUSCloudTask.DAL.Repositories.EmployeeRepository;

namespace SUSCloudTask.BLL.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddEmployeeAsync(AddEmployeeDto employeeDto)
        {
            return await _employeeRepository.AddEmployeeAsync(new Employee
            {
                Address = employeeDto.Address,
                Name = employeeDto.Name,
                Department = employeeDto.Department,
                EndDate = employeeDto.EndDate,
                Position = employeeDto.Position,
                Project = employeeDto.Project,
                Salary = employeeDto.Salary,
                StartDate = employeeDto.StartDate
            });
        }

        public async Task<bool> UpdateEmployeeAsync(EditEmployeeDTO employeeDto)
        {
            return await _employeeRepository.UpdateEmployeeAsync(new Employee
            {
                EmployeeID = employeeDto.EmployeeID,
                Address = employeeDto.Address,
                Name = employeeDto.Name,
                Department = employeeDto.Department,
                EndDate = employeeDto.EndDate,
                Position = employeeDto.Position,
                Project = employeeDto.Project,
                Salary = employeeDto.Salary,
                StartDate = employeeDto.StartDate
            });
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}

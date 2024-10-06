using SUSCloudTask.BLL.DTOs.Employee;
using SUSCloudTask.DAL.Entities;

namespace SUSCloudTask.BLL.Services.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployeesAsync();
        public Task<Employee?> GetEmployeeAsync(int id);
        public Task<bool> AddEmployeeAsync(AddEmployeeDto employeeDto);
        public Task<bool> UpdateEmployeeAsync(EditEmployeeDTO employeeDto);
        public Task<bool> DeleteEmployeeAsync(int id);

    }
}

using SUSCloudTask.DAL.Entities;

namespace SUSCloudTask.DAL.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee?> GetByIdAsync(int id);
        public Task<bool> AddEmployeeAsync(Employee employee);
        public Task<bool> UpdateEmployeeAsync(Employee employee);
        public Task<bool> DeleteEmployeeAsync(int id);

    }
}

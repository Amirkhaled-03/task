using SUSCloudTask.DAL.Entities;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace SUSCloudTask.DAL.Repositories.EmployeeRepository
{
    public class EmployeeRepositoy : IEmployeeRepository
    {
        private readonly string _connection;

        public EmployeeRepositoy(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection myConnection = new SqlConnection(_connection))
            {
                SqlCommand myCommand = new SqlCommand("SP_GetEmployeesData", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                await myConnection.OpenAsync();

                using (SqlDataReader reader = await myCommand.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Employee employee = new Employee
                        {
                            EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Position = reader.GetString(reader.GetOrdinal("Position")),
                            Department = reader.GetString(reader.GetOrdinal("Department")),
                            Salary = reader.GetString(reader.GetOrdinal("Salary")),
                            CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            Project = reader.GetString(reader.GetOrdinal("Project")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                            EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),

                        };

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(_connection))
            {
                SqlCommand myCommand = new SqlCommand("SP_GetEmployeeData", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                myCommand.Parameters.AddWithValue("@EmployeeId", id);

                await myConnection.OpenAsync();

                using (SqlDataReader reader = await myCommand.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Employee employee = new Employee();
                        employee = new Employee
                        {
                            EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Position = reader.GetString(reader.GetOrdinal("Position")),
                            Department = reader.GetString(reader.GetOrdinal("Department")),
                            Salary = reader.GetString(reader.GetOrdinal("Salary")),
                            CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            Project = reader.GetString(reader.GetOrdinal("Project")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                            EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),

                        };

                        return employee;
                    }
                }
            }

            return null;
        }

        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            using (SqlConnection myConnection = new SqlConnection(_connection))
            {
                SqlCommand myCommand = new SqlCommand("SP_AddEmployeesData", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                myCommand.Parameters.AddWithValue("@Name", employee.Name);
                myCommand.Parameters.AddWithValue("@Position", employee.Position);
                myCommand.Parameters.AddWithValue("@Department", employee.Department);
                myCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                myCommand.Parameters.AddWithValue("@Project", employee.Project);
                myCommand.Parameters.AddWithValue("@Address", employee.Address);
                myCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                myCommand.Parameters.AddWithValue("@EndDate", employee.EndDate);

                await myConnection.OpenAsync();

                int rowsAffected = await myCommand.ExecuteNonQueryAsync();

                return rowsAffected > 0 ? true : false;
            }

        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            using (SqlConnection myConnection = new SqlConnection(_connection))
            {
                SqlCommand myCommand = new SqlCommand("SP_EditEmployeeDeta", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                myCommand.Parameters.AddWithValue("@employeeId", employee.EmployeeID);
                myCommand.Parameters.AddWithValue("@Name", employee.Name);
                myCommand.Parameters.AddWithValue("@Position", employee.Position);
                myCommand.Parameters.AddWithValue("@Department", employee.Department);
                myCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                myCommand.Parameters.AddWithValue("@Project", employee.Project);
                myCommand.Parameters.AddWithValue("@Address", employee.Address);
                myCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                myCommand.Parameters.AddWithValue("@EndDate", employee.EndDate);

                await myConnection.OpenAsync();

                int rowsAffected = await myCommand.ExecuteNonQueryAsync();

                return rowsAffected > 0 ? true : false;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            using (SqlConnection myConnection = new SqlConnection(_connection))
            {
                SqlCommand myCommand = new SqlCommand("SP_DeleteEmployeeData", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                myCommand.Parameters.AddWithValue("@employeeId", id);

                await myConnection.OpenAsync();

                int rowsAffected = await myCommand.ExecuteNonQueryAsync();

                return rowsAffected > 0 ? true : false;
            }
        }

    }
}

using Dapper;
using EMployeeManagementWithoutEntity.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EMployeeManagementWithoutEntity.Repository
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<EmployeeViewModel>("sp_GetAllEmployees",
                                                           commandType: CommandType.StoredProcedure);
            }
        }

        public EmployeeViewModel GetEmployeeById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<EmployeeViewModel>("sp_GetEmployeeById", new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddEmployee(EmployeeViewModel employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_AddEmployee", new
                {
                    employee.FirstName,
                    employee.LastName,
                    employee.Email,
                    employee.Salary
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateEmployee(EmployeeViewModel employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_UpdateEmployee", new
                {
                    employee.EmployeeID,
                    employee.FirstName,
                    employee.LastName,
                    employee.Email,
                    employee.Salary
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_DeleteEmployee", new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool EmployeeExists(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<bool>("sp_EmployeeExists", new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

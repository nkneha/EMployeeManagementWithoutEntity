using EMployeeManagementWithoutEntity.Models;

namespace EMployeeManagementWithoutEntity.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeViewModel> GetAllEmployees();
        EmployeeViewModel GetEmployeeById(int id);
        void AddEmployee(EmployeeViewModel employee);
        void UpdateEmployee(EmployeeViewModel employee);
        void DeleteEmployee(int id);
        bool EmployeeExists(int id);
    }
}

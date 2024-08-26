using EMployeeManagementWithoutEntity.Models;
using EMployeeManagementWithoutEntity.Repository;

namespace EMployeeManagementWithoutEntity.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public EmployeeViewModel GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public void AddEmployee(EmployeeViewModel employee)
        {
            _employeeRepository.AddEmployee(employee);
        }

        public void UpdateEmployee(EmployeeViewModel employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

        public bool EmployeeExists(int id)
        {
            return _employeeRepository.EmployeeExists(id);
        }
    }

}


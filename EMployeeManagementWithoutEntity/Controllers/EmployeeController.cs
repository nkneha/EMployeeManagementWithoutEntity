using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMployeeManagementWithoutEntity.Models;
using EMployeeManagementWithoutEntity.Services;

namespace EMployeeManagementWithoutEntity.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //It should return all the list for Employees 
        // GET: Employee
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return Json(employees);
        }
        //update employee
        // POST: Employee/EditEmployee
        [HttpPost]
        public IActionResult EditEmployee([FromBody] EmployeeViewModel employeeViewModel)
        {
            if (employeeViewModel == null || !ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid employee data." });
            }
            if (!_employeeService.EmployeeExists(employeeViewModel.EmployeeID))
            {
                return NotFound(new { message = "Employee not found." });
            }
            _employeeService.UpdateEmployee(employeeViewModel);

            return Json(new { message = "Employee updated successfully." });
        }


        // POST: Employee/AddOrEdit/0
        [HttpPost]
        public IActionResult AddNewEmp([FromBody] EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }


            
                _employeeService.AddEmployee(employeeViewModel);
                return Ok("Employee added successfully.");
            }
            


        //Employee/delete
        [HttpPost]
        
        public IActionResult Delete(int id)
        {
            var employeeViewModel = _employeeService.GetEmployeeById(id);
            if (employeeViewModel == null)
            {
                return NotFound("Employee not found.");
            }
            _employeeService.DeleteEmployee(id);
            return Json(new { message = "Employee deleted successfully." });
        }

    }
}

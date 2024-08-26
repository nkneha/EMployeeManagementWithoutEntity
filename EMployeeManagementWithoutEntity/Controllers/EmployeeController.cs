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
        // GET: Employee/AddOrEdit/5
        [HttpGet]
        public IActionResult AddOrEdit(int? id)
        {
            if (id.HasValue)
            {
                var employeeViewModel = _employeeService.GetEmployeeById(id.Value);
                if (employeeViewModel == null)
                {
                    return NotFound("Employee not found.");
                }
                return Ok(employeeViewModel); // Return the employee data
            }
            return BadRequest("Employee ID is required for editing.");
        }

        
        // POST: Employee/AddOrEdit/0
        [HttpPost]
        public IActionResult AddOrEdit([FromBody] EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            if (employeeViewModel.EmployeeID == 0)
            {
                _employeeService.AddEmployee(employeeViewModel);
                return Ok("Employee added successfully.");
            }
            else
            {
                if (!_employeeService.EmployeeExists(employeeViewModel.EmployeeID))
                {
                    return NotFound("Employee not found.");
                }
                _employeeService.UpdateEmployee(employeeViewModel);
                return Ok("Employee updated successfully.");
            }
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

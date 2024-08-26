using System.ComponentModel.DataAnnotations;

namespace EMployeeManagementWithoutEntity.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        
    }
}

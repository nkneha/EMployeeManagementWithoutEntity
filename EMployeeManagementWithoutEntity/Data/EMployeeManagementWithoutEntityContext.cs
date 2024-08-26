using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMployeeManagementWithoutEntity.Models;

namespace EMployeeManagementWithoutEntity.Data
{
    public class EMployeeManagementWithoutEntityContext : DbContext
    {
        public EMployeeManagementWithoutEntityContext (DbContextOptions<EMployeeManagementWithoutEntityContext> options)
            : base(options)
        {
        }

        public DbSet<EMployeeManagementWithoutEntity.Models.EmployeeViewModel> EmployeeViewModel { get; set; } = default!;
    }
}

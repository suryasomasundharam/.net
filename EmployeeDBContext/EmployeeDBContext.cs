using Microsoft.EntityFrameworkCore;
using newproject2.Models;

namespace newproject2.EmployeeDBContext
{
    public class EmployeeDBContext:DbContext

    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options):base(options) 
        { 
        }
        public DbSet<EmployeeModel> Employeedb { get; set; }

    }
    
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using newproject2.Models;

namespace newproject2.EmployeeDBContext
{
    public class EmployeeDetailsDBContext:IdentityDbContext

    {
        private DbContextOptions _options;
        public EmployeeDetailsDBContext(DbContextOptions DbContext) :base(DbContext) 
        {
            _options = DbContext;
        }

        public DbSet<loginfirst> logiuser { get; set; }
        public DbSet<Userlogin> login { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<EmployeeModel> Employeedb { get; set; }


    }
    
}

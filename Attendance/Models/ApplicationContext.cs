using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Models
{
    public class ApplicationContext:IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        
        }

       
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Attendance.Models
{
    public class Employee
    {
       
        public int Id { get; set; }
    
        public string Name { get; set; }

        public virtual List<EmployeeAttendance> Attendance { get; set; }

    }
}

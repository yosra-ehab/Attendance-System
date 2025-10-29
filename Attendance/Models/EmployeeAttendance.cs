namespace Attendance.Models
{
    public class EmployeeAttendance
    {
        public int id { get; set; }
        public DateTime attendanceTime { get; set; }
        public DateTime?leavetime { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

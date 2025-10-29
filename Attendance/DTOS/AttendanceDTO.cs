namespace Attendance.DTOS
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public DateTime attendanceTime { get; set; }
        public DateTime? leavetime { get; set; }
        public string employeeName { get; set; }

    }
}

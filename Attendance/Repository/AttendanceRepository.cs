using Attendance.Models;

namespace Attendance.Repository
{
    public class AttendanceRepository
    {
        ApplicationContext db;
        public AttendanceRepository(ApplicationContext db)
        {
            this.db = db;
        }



        public List<EmployeeAttendance> GetAll()
        {
            return db.EmployeeAttendances.ToList();
        }

        // ✅ Get attendance record by id
        public EmployeeAttendance GetById(int id)
        {
            return db.EmployeeAttendances.Find(id);
        }

        // ✅ Add new attendance record
        public void Add(EmployeeAttendance attendance)
        {
            db.EmployeeAttendances.Add(attendance);
        }

        // ✅ Save changes
        public void Save()
        {
            db.SaveChanges();
        }


    }

    }


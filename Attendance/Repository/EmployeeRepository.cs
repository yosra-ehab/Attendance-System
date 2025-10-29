using Attendance.Models;

namespace Attendance.Repository
{
    public class EmployeeRepository
    {
        ApplicationContext db;
        public EmployeeRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return db.Employees.Find(id);
        }
        public void add(Employee emp)
        {
            db.Employees.Add(emp);
        }
        public void update(Employee emp)
        {
            var empolyee = db.Employees.Find(emp.Id);
            if (empolyee != null)
            {
                empolyee.Name = emp.Name;
                
            }
        }
        //public void update(Employee emp)
        //{
        //    db.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //}
        public void delete(int id)
        { 
            var emp = db.Employees.Find(id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
            }

        }
        public void save()
        {
            db.SaveChanges();
        }

    }
}

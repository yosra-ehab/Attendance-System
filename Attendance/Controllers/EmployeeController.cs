using Attendance.DTOS;
using Attendance.Models;
using Attendance.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepository repo;
        public EmployeeController(EmployeeRepository repo)
        {
            this.repo = repo;
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee e)
        {
            //if (e == null) return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            repo.add(e);
            repo.save();
        

            return CreatedAtAction("getById", new { id = e.Id }, e);


        }
        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            Employee emp = repo.GetById(id);

            if (emp == null)
                return NotFound();


            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                Id = emp.Id,
                Name = emp.Name
            };

            return Ok(employeeDTO);
        }
        [HttpPut("{id}")]
        public ActionResult updateEmp(int id, Employee emp)
        {
            if (emp == null && id != emp.Id)
                return NotFound();
           repo.update(emp);
            repo.save();
            return Ok(emp);
        }
        //[HttpPut("{id}")]
        //public ActionResult updateEmp(int id, Employee emp)
        //{
        //    if (emp == null && id != emp.Id )
        //        return NotFound();
        //    Db.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    Db.SaveChanges();
        //    return Ok(emp);
        //}
        [HttpDelete("{id}")]
        public ActionResult deleteEmp(int id)
        {
           repo.delete(id);
            repo.save();
            return NoContent();
           
        }
        [HttpGet]
        public ActionResult getAllEmployees()
        {
            List<Employee> employees = repo.GetAll();
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();

            foreach (var emp in employees)
            {
                EmployeeDTO dto = new EmployeeDTO
                {
                    Id = emp.Id,
                    Name = emp.Name
                };
                employeeDTOs.Add(dto);
            }
            return Ok(employeeDTOs);

        }

    }
}

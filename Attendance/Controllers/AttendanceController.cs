using Attendance.DTOS;
using Attendance.Models;
using Attendance.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {

        AttendanceRepository attendanceRepo;
        EmployeeRepository empRepo;
        public AttendanceController(AttendanceRepository attendanceRepo, EmployeeRepository empRepo)
            {
                this.attendanceRepo = attendanceRepo;
                this.empRepo = empRepo;
        }

            [HttpPost("addAttendance/{employeeId}")]
            public ActionResult addAttendance(int employeeId)
            {
                Employee emp = empRepo.GetById(employeeId);
            //if (employeeId != emp.Id)
            //    return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var attendance = new EmployeeAttendance
                {
                    EmployeeId = employeeId,
                    attendanceTime = DateTime.Now,
                    leavetime = null

                };

            attendanceRepo.Add(attendance);
            attendanceRepo.Save();
            return Ok();
            }

            [HttpPost("leaveTime/{employeeId}")]
            public ActionResult leaveTime(int employeeId)
            {
                Employee emp = empRepo.GetById(employeeId);
            //if (employeeId != emp.Id)
            //    return NotFound();
            if ( !ModelState.IsValid)
                    return BadRequest(ModelState);

            var empAttendance = attendanceRepo.GetAll().Where(e => e.EmployeeId == employeeId && e.leavetime == null).FirstOrDefault();

                if (empAttendance == null)
                    return BadRequest();

                empAttendance.leavetime= DateTime.Now;
               
                attendanceRepo.Save();
            return Ok();



            }
        [HttpGet("getAttendanceList/{employeeId}")]
        public ActionResult getAttendanceList(int employeeId)
        {
            var emp = empRepo.GetById(employeeId);

            if (emp == null)
                return NotFound();

            var attendance = attendanceRepo.GetAll().Where(e => e.EmployeeId == employeeId).ToList();

            if (attendance==null)
                return BadRequest("This Employee is Not Found");


            List<EmployeeAttendance> attendanceList = new List<EmployeeAttendance>();
            List<AttendanceDTO> attendanceDTOs = new List<AttendanceDTO>();
            foreach (var att in attendance)
            {
                AttendanceDTO attendanceDTO = new AttendanceDTO
                {
                    Id = att.id,
                    employeeName = emp.Name,
                    attendanceTime = att.attendanceTime,
                    leavetime = att.leavetime
                   
                };
                attendanceDTOs.Add(attendanceDTO);
             
            }
            return Ok(attendanceDTOs);
        }


            


               

               
             


            
                


            

        }
    }


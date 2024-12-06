using Attendace_Std.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Attendace_Std.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       private AppDbContext _repo;
        public StudentController(AppDbContext repoBase)
        {
            _repo = repoBase;
        }
        [HttpPost("Register New Student")]
        public async Task<IActionResult> Register( Student student)
        {
              if (student.Password != student.Repassword)
                {
                    return BadRequest("Passwords Not Repassword .");
                }
              _repo.Students.Add(student);
              _repo.SaveChanges();  
              return Ok(student);
        }
       
        [HttpGet("Login")]
        public async Task<bool> Login(string Email,string Password)
        {
            Student ? res = _repo.Students.FirstOrDefault(s => s.EmailAddress == Email);
            if (res == null||res.Password != Password )
            {
                return false;
            }
            HttpContext.Session.SetString("UserEmail", res.EmailAddress); 
            HttpContext.Session.SetInt32("UserId", res.Id); 
            return true;
        }
        [HttpGet("Submeet Form")]
        public async Task<bool> Attendace(string supervisor_name,string factory_Name,string location )
        {
            Student_attendace student_Attendace = new Student_attendace();  
            var stdId = HttpContext.Session.GetInt32("UserId");
            student_Attendace.Student_Id = (int)stdId;
            int ? fac_id=_repo.factories.FirstOrDefault(f => f.Name==factory_Name).Id;
            int ? super_id=_repo.supervisors.FirstOrDefault(f => f.Name==supervisor_name).Id;
            if (fac_id != null && super_id != null)
            {
                student_Attendace.Supervisor_id = (int)super_id;
                student_Attendace.fac_id = (int)fac_id;
                student_Attendace.Location = location;
                
                _repo.student_attendaces.Add(student_Attendace);
                _repo.SaveChanges();    
                return true;    
            }   

            return false;
        }
       
       /* factoryname
 * subervisor
 * location
* data*/


    }
}

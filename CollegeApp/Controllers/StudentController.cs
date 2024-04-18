using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("All" , Name ="GetAllStudents")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public  ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(CollegeRepository.Students);
        }

        [HttpGet]
        [Route("{id:int}" , Name ="GetStudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult< Student> GetStudentbyid(int id)
        {
            if (id <= 0) {
                return BadRequest();          
            }
            var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            if(student == null)
            {
                return NotFound($"The Student With id {id} not Found" );
            }

            return Ok(student);
        }

        [HttpGet("{name:alpha}", Name = "GetStudentByName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public ActionResult< Student> GetStudentbyname(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            var student = CollegeRepository.Students.Where(n => n.studentName == name).FirstOrDefault();
            if (student == null)
            {
                return NotFound($"The Student With name {name} not Found");
            }
            return Ok(student);
        }

        [HttpDelete("{id}", Name = "DeleteStudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult< bool> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            if (student == null)
            {
                return NotFound($"The Student With id {id} not Found");
            }
            
            CollegeRepository.Students.Remove(student);
            return Ok(true);
        }

    }
}

using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services.Students;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PruebaEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ISvStudent _svStudent;
        public StudentController(ISvStudent svStudent)
        {
            _svStudent = svStudent;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _svStudent.GetAllStudent();
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _svStudent.GetStudentById(id);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _svStudent.AddStudent(student);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            _svStudent.UpdateStudent(id, new Student
            {
                Name = student.Name,
                LastName = student.LastName
            });
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _svStudent.DeleteStudent(id);
        }
    }
}

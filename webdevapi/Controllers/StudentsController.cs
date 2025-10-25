using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using webdevapi.Models;
using webdevapi.Repositories;


namespace webdevapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentsController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _repository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            Log.Information("Добавлен новый студент: {@student}", student);

            var newStudent = await _repository.AddAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest();

            await _repository.UpdateAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}

using _WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace _WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly PracticeWebAppContext context;

        public StudentsController(PracticeWebAppContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await this.context.Students.ToListAsync();
            if (data != null)
                return Ok(data);
            else
                return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudents(int id)
        {
            var data = await this.context.Students.FindAsync(id);
            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student s)
        {
            await this.context.Students.AddAsync(s);
            await this.context.SaveChangesAsync();
            return Ok(s);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int? id, Student s)
        {
            if (id != s.Id)
            {
                return BadRequest();
            }
            this.context.Entry(s).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            return Ok(s);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int? id)
        {
            var data = await this.context.Students.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            this.context.Students.Remove(data);
            await this.context.SaveChangesAsync();
            return Ok(data);
        }

    }
}

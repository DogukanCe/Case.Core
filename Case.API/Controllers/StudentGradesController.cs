using Case.Core.Model;
using Case.Serivce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Case.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradesController : ControllerBase
    {
        private readonly StudentGradesService studentGradesService;

        public StudentGradesController(StudentGradesService studentGradesService)
        {
            this.studentGradesService = studentGradesService;
        }

        [HttpGet]
        public ActionResult<IList<StudentGrades>> GetAll()
        {
            var studentGrades = studentGradesService.GetAll();
            return Ok(studentGrades);
        }

        [HttpGet("{id}")]
        public ActionResult<StudentGrades> GetById(int id)
        {
            var studentGrades = studentGradesService.GetById(id);
            if (studentGrades == null)
            {
                return NotFound();
            }
            return Ok(studentGrades);
        }

        [HttpPost]
        public ActionResult<StudentGrades> Insert(StudentGrades studentGrades)
        {
            studentGradesService.Insert(studentGrades);
            return CreatedAtAction(nameof(GetById), new { id = studentGrades.Id }, studentGrades);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentGrades studentGrades)
        {
            if (id != studentGrades.Id)
            {
                return BadRequest();
            }

            studentGradesService.Update(studentGrades);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var studentGrades = studentGradesService.GetById(id);
            if (studentGrades == null)
            {
                return NotFound();
            }

            studentGradesService.Delete(id);
            return NoContent();
        }
    }
    }

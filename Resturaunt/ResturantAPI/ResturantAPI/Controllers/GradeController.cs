using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

namespace ResturantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : Controller
    {
        private readonly RestContext _context;
        public GradeController(RestContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            return await _context.Grades.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrade(int id)
        {
            return await _context.Grades.Where(x => x.RestId == id).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade c)
        {
            c.Id = null;
            _context.Grades.Add(c);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostGrade", new { id = c.Id }, c);
        }
    }
}

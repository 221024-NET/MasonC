using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

namespace ResturantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : Controller
    {
        private readonly RestContext _context;

        public ScoreController(RestContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
            return await _context.Scores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Score>>> GetScore(int id)
        {
            return await _context.Scores.Where(x => x.RestId == id).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score c)
        {
            c.Id = null;
            _context.Scores.Add(c);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostScore", new { id = c.Id }, c);
        }
    }
}

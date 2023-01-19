using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

namespace ResturantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestConnCuisineController : Controller
    {
        private readonly RestContext _context;
        public RestConnCuisineController(RestContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestConnCuisine>>> GetRestConnCuisine()
        {
            return await _context.RestConnCuisines.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<RestConnCuisine>> PostRestConnCuisine(RestConnCuisine c)
        {
            c.Id = null;
            _context.RestConnCuisines.Add(c);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostRestConnCuisine", new { id = c.Id }, c);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

namespace ResturantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuisineController : Controller
    {
        private readonly RestContext _context;
        public CuisineController(RestContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuisine>>> GetCuisines()
        {
            return await _context.Cuisines.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cuisine>> PostCuisine(Cuisine c)
        {
            c.Id = null;
            _context.Cuisines.Add(c);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostCuisien", new { id = c.Id }, c);
        }
    }
}

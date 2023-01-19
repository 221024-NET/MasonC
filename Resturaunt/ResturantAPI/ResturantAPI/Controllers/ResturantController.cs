using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

namespace ResturantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly RestContext _context;

        public RestaurantController(RestContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetResturants()
        {
            if(_context.Resturants == null)
            {
                return NotFound();
            }
            return await _context.Resturants.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurant(int id)
        {
            return _context.Resturants.Where(x => x.Id == id).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant rest)
        {
            rest.Id = null;
            _context.Resturants.Add(rest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostRestaurant", new { id = rest.Id }, rest);
        }
    }
}

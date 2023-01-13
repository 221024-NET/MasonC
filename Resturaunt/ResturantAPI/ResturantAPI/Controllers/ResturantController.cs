using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

namespace ResturantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResturantController : Controller
    {
        private readonly RestContext _context;

        public ResturantController(RestContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resturaunt>>> GetResturants()
        {
            if(_context.Resturants == null)
            {
                return NotFound();
            }
            return await _context.Resturants.ToListAsync();
        }
    }
}

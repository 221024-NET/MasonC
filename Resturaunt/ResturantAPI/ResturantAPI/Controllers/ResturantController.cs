using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return await _context.Resturants.ToListAsync();
        }
    }
}

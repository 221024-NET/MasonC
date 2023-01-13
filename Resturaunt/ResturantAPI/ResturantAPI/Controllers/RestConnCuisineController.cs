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
    }
}

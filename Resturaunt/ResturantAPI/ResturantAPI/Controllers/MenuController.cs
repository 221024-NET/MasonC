using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;

namespace ResturantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        private readonly RestContext _context;
        public MenuController(RestContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return await _context.Menus.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu c)
        {
            c.Id = null;
            _context.Menus.Add(c);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostMenu", new { id = c.Id }, c);
        }
    }
}

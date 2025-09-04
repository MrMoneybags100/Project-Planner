using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectplanner.Data;
using projectplanner.Models;

namespace projectplanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProjectLinksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserProjectLinksController(AppDbContext context)
        {
            _context = context;
        }


        #region GET


        //GET: All users, Probably get rid of this later
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetLinks()
        {
            var links = await _context.UserProjectLinks.ToListAsync();

            if (!links.Any())
            {
                return NotFound($"No links found.");
            }

            return Ok(links);
        }


        #endregion GET


        #region POST


        


        #endregion POST
    }
}
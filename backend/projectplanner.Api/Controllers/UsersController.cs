using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectplanner.Data;
using projectplanner.Models;

namespace projectplanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }


        #region GET


        //GET: All users, Probably get rid of this later
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            if (!users.Any())
            {
                return NotFound($"No users found.");
            }

            return Ok(users);
        }


        #endregion GET


        #region POST


        [HttpPost("CreateUser")]
        public async Task<ActionResult<Project>> CreateUser(DtoUserCreationInfo userInfo)
        {
            User newUser = new User
            {
                UserName = userInfo.userName,
                UserEmail = userInfo.UserEmail
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            var returnDTO = new DtoUserCreatedResult
            {
                UserName = newUser.UserName,
                UserID = newUser.UserID,
            };

            return Ok(returnDTO);
        }


        #endregion POST
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectplanner.Data;
using projectplanner.Models;

namespace projectplanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        //GET: All tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        //GET: Task of a particular ID
        [HttpGet("taskID")]
        public async Task<ActionResult<TaskItem>> GetTask(int taskID)
        {
            var tasks = await _context.Tasks.Where(t => t.TaskID == taskID).ToListAsync();

            if (!tasks.Any())
            {
                return NotFound($"No tasks found with ID: {taskID}");
            }

            return Ok(tasks);
        }

        //GET: All tasks belonging to a group
        [HttpGet("groupID")]
        public async Task<ActionResult<TaskItem>> GetGroupTasks(int groupID)
        {
            var tasks = await _context.Tasks.Where(t => t.GroupID == groupID).ToListAsync();

            if (!tasks.Any())
            {
                return NotFound($"No tasks found for GroupID: {groupID}");
            }

            return Ok(tasks);
        }
    }
}

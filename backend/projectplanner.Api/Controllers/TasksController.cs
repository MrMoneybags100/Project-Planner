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


        #region GET


        //GET: All tasks, Probably get rid of this later
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();

            if (!tasks.Any())
            {
                return NotFound($"No tasks found.");
            }

            return Ok(tasks);
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

        //GET: All tasks belonging to a project
        [HttpGet("projectID")]
        public async Task<ActionResult<TaskItem>> GetGroupTasks(int projectID)
        {
            var tasks = await _context.Tasks.Where(t => t.ProjectID == projectID).ToListAsync();

            if (!tasks.Any())
            {
                return NotFound($"No tasks found for GroupID: {projectID}");
            }

            return Ok(tasks);
        }


        #endregion GET


        #region POST


        


        #endregion POST
    }
}

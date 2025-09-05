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
        [HttpGet("GetTasks")]
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
        [HttpGet("GetProjectTasks")]
        public async Task<ActionResult<TaskItem>> GetProjectTasks(int projectID)
        {
            var tasks = await _context.Tasks.Where(t => t.ProjectID == projectID).ToListAsync();

            if (!tasks.Any())
            {
                return NotFound($"No tasks found for ProjectID: {projectID}");
            }

            return Ok(tasks);
        }

        //GET: All end-point tasks belonging to a project
        [HttpGet("GetProjectEndPointTasks")]
        public async Task<ActionResult<TaskItem>> GetProjectEndPointTasks(int projectID)
        {
            var leafTasks = await _context.Tasks.Where(t => t.ProjectID == projectID && !t.IsCompleted && !_context.Tasks.Any(child => child.ParentID == t.TaskID)).ToListAsync();

            if (!leafTasks.Any())
            {
                return NotFound($"No tasks found for ProjectID: {projectID}");
            }

            return Ok(leafTasks);
        }


        #endregion GET


        #region POST


        // POST: Create a Project, Also creates user project link
        [HttpPost("CreateTask")]
        public async Task<ActionResult<Project>> CreateProject(DtoTaskCreationInfo taskInfo)
        {

            TaskItem newTask = new TaskItem
            {
                ParentID = taskInfo.ParentID,
                ProjectID = taskInfo.ProjectID,
                CreatedID = taskInfo.UserID,
                AssignedToID = taskInfo.AssignedToID,
                TaskTitle = taskInfo.TaskTitle,
                TaskDescription = taskInfo.TaskDescription,
                IsDefaultExpanded = taskInfo.IsDefaultExpanded,
                CreatedDate = DateTime.Now,
                IsCompleted = false,
                LastEditedID = taskInfo.UserID,
                LastEditedDate = DateTime.Now
            };
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();

            var returnDTO = new DtoTaskCreatedResult
            {
                TaskTitle = newTask.TaskTitle,
                TaskID = newTask.TaskID
            };

            return Ok(returnDTO);
        }


        #endregion POST


        #region PUT


        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(DtoTaskEditingInfo updatedTaskInfo)
        {
            var existingTask = await _context.Tasks.FindAsync(updatedTaskInfo.TaskID);
            if (existingTask == null)
            {
                return NotFound($"Task with ID: {updatedTaskInfo.TaskID} not found.");
            }

            existingTask.AssignedToID = updatedTaskInfo.AssignedToID;
            existingTask.TaskTitle = updatedTaskInfo.TaskTitle;
            existingTask.TaskDescription = updatedTaskInfo.TaskDescription;
            existingTask.IsDefaultExpanded = updatedTaskInfo.IsDefaultExpanded;
            existingTask.IsCompleted = updatedTaskInfo.IsCompleted;
            existingTask.CompletedByID = updatedTaskInfo.CompletedByID;
            existingTask.CompletedDate = updatedTaskInfo.CompletedDate;
            existingTask.LastEditedID = updatedTaskInfo.UserID;
            existingTask.LastEditedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        #endregion PUT
        }
}

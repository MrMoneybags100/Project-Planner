using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectplanner.Data;
using projectplanner.Models;

namespace projectplanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }


        #region GET


        //GET: All projects, Probably get rid of this later
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetProjects()
        {
            var projects = await _context.Projects.ToListAsync();

            if (!projects.Any())
            {
                return NotFound($"No projects found.");
            }

            return Ok(projects);
        }


        //GET: All Projects a user is a part of
        [HttpGet("GetUserProjects")]
        public async Task<ActionResult<TaskItem>> GetUserProjects(int userID)
        {
            var projects = await _context.Projects.Where(proj => _context.UserProjectLinks.Where(link => link.UserID == userID).Select(link => link.ProjectID).Contains(proj.ProjectID)).ToListAsync();

            if (!projects.Any())
            {
                return NotFound($"No projects found for user: {userID}");
            }

            return Ok(projects);
        }


        #endregion GET


        #region POST


        // POST: Create a Project, Also creates user project link
        [HttpPost("CreateProject")]
        public async Task<ActionResult<Project>> CreateProject(DtoProjectCreationInfo projectInfo)
        {

            Project newProject = new Project
            {
                CreatedID = projectInfo.UserID,
                LastEditedID = projectInfo.UserID,
                ProjectTitle = projectInfo.ProjectTitle,
                ProjectDescription = projectInfo.ProjectDescription,
                IsCompleted = false,
                IsDefaultExpanded = projectInfo.IsDefaultExpanded,
                CreatedDate = DateTime.Now,
                LastEditedDate = DateTime.Now
            };
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();

            UserProjectLink newLink = new UserProjectLink
            {
                UserID = projectInfo.UserID,
                ProjectID = newProject.ProjectID,
                IsOwner = true,
                IsOrganiser = true
            };
            _context.UserProjectLinks.Add(newLink);
            await _context.SaveChangesAsync();

            var returnDTO = new DtoProjectCreatedResult
            {
                ProjectTitle = newProject.ProjectTitle,
                ProjectID = newProject.ProjectID,
                UserProjectLinkID = newLink.LinkID
            };

            return Ok(returnDTO);
        }


        #endregion POST
    }
}
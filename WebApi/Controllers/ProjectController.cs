using Infrastructure.Business.Domains.Dto;
using Infrastructure.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { Errors = errors });
            }

            try
            {
                var result = await _projectService.CreateProjectAsync(request);
                return result ? Ok("Projekt skapat") : BadRequest("Misslyckades");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects([FromQuery] string sortByDaysLeft = "asc")
        {
            var projects = await _projectService.GetAllProjectsAsync(sortByDaysLeft);
            return Ok(projects);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectRequest request)
        {
            var success = await _projectService.UpdateProjectAsync(id, request);

            if (success)
                return Ok(new { message = "Projekt uppdaterat!" });

            return BadRequest(new { message = "Kunde inte uppdatera projektet." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var success = await _projectService.DeleteProjectAsync(id);

            if (success)
                return Ok(new { message = "Projektet har tagits bort." });

            return NotFound(new { message = "Projektet hittades inte eller kunde inte tas bort." });
        }
    }
}

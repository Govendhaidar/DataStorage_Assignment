using Business.DTOs;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_WebAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;

       
        // Get all Projects
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Projects = await _projectService.GetAllProjectsAsync();
            return Ok(Projects);
        }

        // Get Project by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Project = await _projectService.GetProjectByIdAsync(id);
            if (Project == null) return NotFound();
            return Ok(Project);
        }

        // Create a new Project
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectRegistrationForm form)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var Project = await _projectService.CreateProjectAsync(form);
            return CreatedAtAction(nameof(GetById), new { id = Project.Id }, Project);
        }

        //// Update an existing Project
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] ProjectUpdateForm form)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    var updatedProject = await _projectService.UpdateProjectAsync(id, form);
        //    if (updatedProject == null) return NotFound();

        //    return Ok(updatedProject);
        //}

        // Delete a Project
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _projectService.DeleteProjectAsync(id);
        //    if (!result) return NotFound();

        //    return NoContent();
        //}
    }
}


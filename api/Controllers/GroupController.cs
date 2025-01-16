using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAllGroupsAsync();
            return Ok(groups);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group == null) return NotFound();
            return Ok(group);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GroupDTO groupDto)
        {
            await _groupService.AddGroupAsync(groupDto);
            return CreatedAtAction(nameof(GetById), new { id = groupDto.CodeGroupe }, groupDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GroupDTO groupDto)
        {
            if (id != groupDto.CodeGroupe) return BadRequest();
            await _groupService.UpdateGroupAsync(groupDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupService.DeleteGroupAsync(id);
            return NoContent();
        }


    }
}

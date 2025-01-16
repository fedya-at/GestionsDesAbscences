using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClasseController : ControllerBase
    {
        private readonly IClasseService _classeService;

        public ClasseController(IClasseService classeService)
        {
            _classeService = classeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var classes = await _classeService.GetAllClassesAsync();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var classe = await _classeService.GetClassByIdAsync(id);
            if (classe == null) return NotFound();
            return Ok(classe);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClasseDTO classeDto)
        {
            await _classeService.AddClassAsync(classeDto);
            return CreatedAtAction(nameof(GetById), new { id = classeDto.CodeClasse }, classeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClasseDTO classeDto)
        {
            if (id != classeDto.CodeClasse) return BadRequest();

            await _classeService.UpdateClassAsync(classeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _classeService.DeleteClassAsync(id);
            return NoContent();
        }
    }
}

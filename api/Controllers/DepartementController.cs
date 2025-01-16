using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartementController : Controller
    {
        private readonly IDepartementService _departementService;
        public DepartementController(IDepartementService departementService)
        {
            _departementService = departementService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departements = await _departementService.GetAllDepartmentsAsync();
            return Ok(departements);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var departement = await _departementService.GetDepartmentByIdAsync(id);
            if (departement == null) return NotFound();
            return Ok(departement);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDTO departementDto)
        {
            await _departementService.AddDepartmentAsync(departementDto);
            return CreatedAtAction(nameof(GetById), new { id = departementDto.DepartmentId }, departementDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DepartmentDTO departementDto)
        {
            if (id != departementDto.DepartmentId) return BadRequest();
            await _departementService.UpdateDepartmentAsync(departementDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departementService.DeleteDepartmentAsync(id);
            return NoContent();
        }

    }
}

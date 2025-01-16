using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EtudiantController : ControllerBase
{
    private readonly IEtudiantService _etudiantService;

    public EtudiantController(IEtudiantService etudiantService)
    {
        _etudiantService = etudiantService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var etudiants = await _etudiantService.GetAllEtudiantsAsync();
        return Ok(etudiants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var etudiant = await _etudiantService.GetEtudiantByIdAsync(id);
        if (etudiant == null) return NotFound();
        return Ok(etudiant);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EtudiantDTO etudiantDto)
    {
        await _etudiantService.AddEtudiantAsync(etudiantDto);
        return CreatedAtAction(nameof(GetById), new { id = etudiantDto.CodeEtudiant }, etudiantDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EtudiantDTO etudiantDto)
    {
        if (id != etudiantDto.CodeEtudiant) return BadRequest();

        await _etudiantService.UpdateEtudiantAsync(etudiantDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _etudiantService.DeleteEtudiantAsync(id);
        return NoContent();
    }
}

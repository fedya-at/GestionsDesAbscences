using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MatiereController : ControllerBase
{
    private readonly IMatiereService _matiereService;

    public MatiereController(IMatiereService matiereService)
    {
        _matiereService = matiereService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var matieres = await _matiereService.GetAllMatieresAsync();
        return Ok(matieres);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var matiere = await _matiereService.GetMatiereByIdAsync(id);
        if (matiere == null) return NotFound();
        return Ok(matiere);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MatiereDTO matiereDto)
    {
        await _matiereService.AddMatiereAsync(matiereDto);
        return CreatedAtAction(nameof(GetById), new { id = matiereDto.CodeMatiere }, matiereDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MatiereDTO matiereDto)
    {
        if (id != matiereDto.CodeMatiere) return BadRequest();

        await _matiereService.UpdateMatiereAsync(matiereDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _matiereService.DeleteMatiereAsync(id);
        return NoContent();
    }
}

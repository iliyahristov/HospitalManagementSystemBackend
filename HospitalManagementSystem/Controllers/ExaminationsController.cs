using HospitalManagementSystem.DTOs;
using HospitalManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExaminationsController : ControllerBase
{
    private readonly IExaminationService _examinationService;

    public ExaminationsController(IExaminationService examinationService)
    {
        _examinationService = examinationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExaminationDto>>> GetExaminations()
    {
        var examinations = await _examinationService.GetAllExaminationsAsync();
        return Ok(examinations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExaminationDto>> GetExamination(int id)
    {
        var examination = await _examinationService.GetExaminationByIdAsync(id);
        if (examination == null) return NotFound();
        return Ok(examination);
    }

    [HttpPost]
    public async Task<ActionResult<ExaminationDto>> CreateExamination(ExaminationDto examinationDto)
    {
        var createdExamination = await _examinationService.CreateExaminationAsync(examinationDto);
        return CreatedAtAction(nameof(GetExamination), new { id = createdExamination.ExaminationID }, createdExamination);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExamination(int id, ExaminationDto examinationDto)
    {
        await _examinationService.UpdateExaminationAsync(id, examinationDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExamination(int id)
    {
        await _examinationService.DeleteExaminationAsync(id);
        return NoContent();
    }
}
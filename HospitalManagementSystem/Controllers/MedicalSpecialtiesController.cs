using HospitalManagementSystem.DTOs;
using HospitalManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicalSpecialtiesController : ControllerBase
{
    private readonly IMedicalSpecialtyService _medicalSpecialtyService;

    public MedicalSpecialtiesController(IMedicalSpecialtyService medicalSpecialtyService)
    {
        _medicalSpecialtyService = medicalSpecialtyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicalSpecialtyDto>>> GetMedicalSpecialties()
    {
        var specialties = await _medicalSpecialtyService.GetAllMedicalSpecialtiesAsync();
        return Ok(specialties);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MedicalSpecialtyDto>> GetMedicalSpecialty(int id)
    {
        var specialty = await _medicalSpecialtyService.GetMedicalSpecialtyByIdAsync(id);
        if (specialty == null) return NotFound();
        return Ok(specialty);
    }

    [HttpPost]
    public async Task<ActionResult<MedicalSpecialtyDto>> CreateMedicalSpecialty(MedicalSpecialtyDto specialtyDto)
    {
        var createdSpecialty = await _medicalSpecialtyService.CreateMedicalSpecialtyAsync(specialtyDto);
        return CreatedAtAction(nameof(GetMedicalSpecialty), new { id = createdSpecialty.SpecialtyID }, createdSpecialty);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMedicalSpecialty(int id, MedicalSpecialtyDto specialtyDto)
    {
        await _medicalSpecialtyService.UpdateMedicalSpecialtyAsync(id, specialtyDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicalSpecialty(int id)
    {
        await _medicalSpecialtyService.DeleteMedicalSpecialtyAsync(id);
        return NoContent();
    }
}
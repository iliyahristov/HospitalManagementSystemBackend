using AutoMapper;
using HospitalManagementSystem.DTOs;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repositories;

namespace HospitalManagementSystem.Services;

public interface IMedicalSpecialtyService
{
    Task<IEnumerable<MedicalSpecialtyDto>> GetAllMedicalSpecialtiesAsync();
    Task<MedicalSpecialtyDto> GetMedicalSpecialtyByIdAsync(int id);
    Task<MedicalSpecialtyDto> CreateMedicalSpecialtyAsync(MedicalSpecialtyDto specialtyDto);
    Task UpdateMedicalSpecialtyAsync(int id, MedicalSpecialtyDto specialtyDto);
    Task DeleteMedicalSpecialtyAsync(int id);
}

public class MedicalSpecialtyService : IMedicalSpecialtyService
{
    private readonly IGenericRepository<MedicalSpecialty> _medicalSpecialtyRepository;
    private readonly IMapper _mapper;

    public MedicalSpecialtyService(
        IGenericRepository<MedicalSpecialty> medicalSpecialtyRepository, 
        IMapper mapper)
    {
        _medicalSpecialtyRepository = medicalSpecialtyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicalSpecialtyDto>> GetAllMedicalSpecialtiesAsync()
    {
        var specialties = await _medicalSpecialtyRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MedicalSpecialtyDto>>(specialties);
    }

    public async Task<MedicalSpecialtyDto> GetMedicalSpecialtyByIdAsync(int id)
    {
        var specialty = await _medicalSpecialtyRepository.GetByIdAsync(id);
        return _mapper.Map<MedicalSpecialtyDto>(specialty);
    }

    public async Task<MedicalSpecialtyDto> CreateMedicalSpecialtyAsync(MedicalSpecialtyDto specialtyDto)
    {
        var specialty = _mapper.Map<MedicalSpecialty>(specialtyDto);
        var createdSpecialty = await _medicalSpecialtyRepository.AddAsync(specialty);
        return _mapper.Map<MedicalSpecialtyDto>(createdSpecialty);
    }

    public async Task UpdateMedicalSpecialtyAsync(int id, MedicalSpecialtyDto specialtyDto)
    {
        var existingSpecialty = await _medicalSpecialtyRepository.GetByIdAsync(id);
        if (existingSpecialty == null)
            throw new Exception("Medical Specialty not found");

        _mapper.Map(specialtyDto, existingSpecialty);
        await _medicalSpecialtyRepository.UpdateAsync(existingSpecialty);
    }

    public async Task DeleteMedicalSpecialtyAsync(int id)
    {
        await _medicalSpecialtyRepository.DeleteAsync(id);
    }
}
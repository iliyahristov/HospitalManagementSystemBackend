using AutoMapper;
using HospitalManagementSystem.DTOs;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repositories;

namespace HospitalManagementSystem.Services;

public interface IExaminationService
{
    Task<IEnumerable<ExaminationDto>> GetAllExaminationsAsync();
    Task<ExaminationDto> GetExaminationByIdAsync(int id);
    Task<ExaminationDto> CreateExaminationAsync(ExaminationDto examinationDto);
    Task UpdateExaminationAsync(int id, ExaminationDto examinationDto);
    Task DeleteExaminationAsync(int id);
}

public class ExaminationService : IExaminationService
{
    private readonly IGenericRepository<Examination> _examinationRepository;
    private readonly IMapper _mapper;

    public ExaminationService(
        IGenericRepository<Examination> examinationRepository, 
        IMapper mapper)
    {
        _examinationRepository = examinationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExaminationDto>> GetAllExaminationsAsync()
    {
        var examinations = await _examinationRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ExaminationDto>>(examinations);
    }

    public async Task<ExaminationDto> GetExaminationByIdAsync(int id)
    {
        var examination = await _examinationRepository.GetByIdAsync(id);
        return _mapper.Map<ExaminationDto>(examination);
    }

    public async Task<ExaminationDto> CreateExaminationAsync(ExaminationDto examinationDto)
    {
        var examination = _mapper.Map<Examination>(examinationDto);
        var createdExamination = await _examinationRepository.AddAsync(examination);
        return _mapper.Map<ExaminationDto>(createdExamination);
    }

    public async Task UpdateExaminationAsync(int id, ExaminationDto examinationDto)
    {
        var existingExamination = await _examinationRepository.GetByIdAsync(id);
        if (existingExamination == null)
            throw new Exception("Examination not found");

        _mapper.Map(examinationDto, existingExamination);
        await _examinationRepository.UpdateAsync(existingExamination);
    }

    public async Task DeleteExaminationAsync(int id)
    {
        await _examinationRepository.DeleteAsync(id);
    }
}
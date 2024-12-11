using AutoMapper;
using HospitalManagementSystem.DTOs;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repositories;

namespace HospitalManagementSystem.Services;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
    Task<PatientDto> GetPatientByIdAsync(int id);
    Task<PatientDto> CreatePatientAsync(PatientDto patientDto);
    Task UpdatePatientAsync(int id, PatientDto patientDto);
    Task DeletePatientAsync(int id);
}

// Patient Service Implementation
public class PatientService : IPatientService
{
    private readonly IGenericRepository<Patient> _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(
        IGenericRepository<Patient> patientRepository, 
        IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
    {
        var patients = await _patientRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PatientDto>>(patients);
    }

    public async Task<PatientDto> GetPatientByIdAsync(int id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        return _mapper.Map<PatientDto>(patient);
    }

    public async Task<PatientDto> CreatePatientAsync(PatientDto patientDto)
    {
        var patient = _mapper.Map<Patient>(patientDto);
        var createdPatient = await _patientRepository.AddAsync(patient);
        return _mapper.Map<PatientDto>(createdPatient);
    }

    public async Task UpdatePatientAsync(int id, PatientDto patientDto)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(id);
        if (existingPatient == null)
            throw new Exception("Patient not found");

        _mapper.Map(patientDto, existingPatient);
        await _patientRepository.UpdateAsync(existingPatient);
    }

    public async Task DeletePatientAsync(int id)
    {
        await _patientRepository.DeleteAsync(id);
    }
}
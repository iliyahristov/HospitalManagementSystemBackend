using HospitalManagementSystem.DTOs;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repositories;

namespace HospitalManagementSystem.Services;

using AutoMapper;

public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
    Task<DoctorDto> GetDoctorByIdAsync(int id);
    Task<DoctorDto> CreateDoctorAsync(DoctorDto doctorDto);
    Task UpdateDoctorAsync(int id, DoctorDto doctorDto);
    Task DeleteDoctorAsync(int id);
}

public class DoctorService : IDoctorService
{
    private readonly IGenericRepository<Doctor> _doctorRepository;
    private readonly IMapper _mapper;

    public DoctorService(
        IGenericRepository<Doctor> doctorRepository, 
        IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
    {
        var doctors = await _doctorRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
    }

    public async Task<DoctorDto> GetDoctorByIdAsync(int id)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);
        return _mapper.Map<DoctorDto>(doctor);
    }

    public async Task<DoctorDto> CreateDoctorAsync(DoctorDto doctorDto)
    {
        var doctor = _mapper.Map<Doctor>(doctorDto);
        var createdDoctor = await _doctorRepository.AddAsync(doctor);
        return _mapper.Map<DoctorDto>(createdDoctor);
    }

    public async Task UpdateDoctorAsync(int id, DoctorDto doctorDto)
    {
        var existingDoctor = await _doctorRepository.GetByIdAsync(id);
        if (existingDoctor == null)
            throw new Exception("Doctor not found");

        _mapper.Map(doctorDto, existingDoctor);
        await _doctorRepository.UpdateAsync(existingDoctor);
    }

    public async Task DeleteDoctorAsync(int id)
    {
        await _doctorRepository.DeleteAsync(id);
    }
}
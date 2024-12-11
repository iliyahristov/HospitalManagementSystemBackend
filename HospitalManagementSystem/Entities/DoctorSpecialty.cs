namespace HospitalManagementSystem.Entities;

public class DoctorSpecialty
{
    public int DoctorID { get; set; }
    public Doctor Doctor { get; set; }

    public int SpecialtyID { get; set; }
    public MedicalSpecialty Specialty { get; set; }
}
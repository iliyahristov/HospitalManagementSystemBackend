using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Entities;

public class MedicalSpecialty
{
    [Key]
    public int SpecialtyID { get; set; }
    public string SpecialtyName { get; set; }

    public ICollection<DoctorSpecialty> DoctorSpecialties { get; set; }
}
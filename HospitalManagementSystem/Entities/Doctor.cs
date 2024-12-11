using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Entities;

public class Doctor
{
    [Key]
    public int DoctorID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    
    public ICollection<Examination> Examinations { get; set; }
    public ICollection<DoctorSpecialty> DoctorSpecialties { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Entities;

public class Patient
{
    [Key]
    public int PatientID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string ContactNumber { get; set; }
    public string Address { get; set; }
    
    public ICollection<Examination> Examinations { get; set; }
}
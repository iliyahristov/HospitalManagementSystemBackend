using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Entities;

public class Examination
{
    [Key]
    public int ExaminationID { get; set; }
    
    [ForeignKey("Doctor")]
    public int DoctorID { get; set; }
    public Doctor Doctor { get; set; }

    [ForeignKey("Patient")]
    public int PatientID { get; set; }
    public Patient Patient { get; set; }

    public DateTime ExaminationDate { get; set; }
    public string Diagnosis { get; set; }
    public string Prescription { get; set; }
}
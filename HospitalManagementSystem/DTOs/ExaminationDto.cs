namespace HospitalManagementSystem.DTOs;

public class ExaminationDto
{
    public int ExaminationID { get; set; }
    public int DoctorID { get; set; }
    public int PatientID { get; set; }
    public DateTime ExaminationDate { get; set; }
    public string Diagnosis { get; set; }
    public string Prescription { get; set; }
}
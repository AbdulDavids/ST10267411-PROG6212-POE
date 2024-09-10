namespace PROG6212_POE.Models;

// Models/Claim.cs
public class Claim
{
    public int ClaimID { get; set; }
    public int LecturerID { get; set; }
    public DateTime DateSubmitted { get; set; }
    public float HoursWorked { get; set; }
    public float AmountDue { get; set; }
    public string Status { get; set; } // Pending, Approved, Rejected

    public virtual Lecturer Lecturer { get; set; }
}
namespace EXCELGRAPHING.Models;

public class PolicyHolder
{
    public int PolicyholderID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public ICollection<Policy> Policies { get; set; }
}
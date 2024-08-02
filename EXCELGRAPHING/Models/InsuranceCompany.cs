namespace EXCELGRAPHING.Models;

public class InsuranceCompany
{
    public int InsuranceCompanyID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public ICollection<Policy> Policies { get; set; }
}
namespace EXCELGRAPHING.Models;

public class Policy
{
    public int PolicyID { get; set; }
    public string PolicyNumber { get; set; }
    public int InsuranceCompanyID { get; set; }
    public int PolicyholderID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal CoverageAmount { get; set; }

    public InsuranceCompany InsuranceCompany { get; set; }
    public PolicyHolder Policyholder { get; set; }
    public ICollection<Claim> Claims { get; set; }
}
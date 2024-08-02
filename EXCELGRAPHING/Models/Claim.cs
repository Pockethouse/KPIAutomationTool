namespace EXCELGRAPHING.Models;

public class Claim
{
    public int ClaimID { get; set; }
    public int PolicyID { get; set; }
    public int ProviderID { get; set; }
    public DateTime ClaimDate { get; set; }
    public decimal ClaimAmount { get; set; }
    public string Status { get; set; }

    public Policy Policy { get; set; }
    public Provider Provider { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
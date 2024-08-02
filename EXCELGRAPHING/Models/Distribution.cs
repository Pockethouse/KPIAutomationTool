namespace EXCELGRAPHING.Models;

public class Distribution
{
    public int DistributionID { get; set; }
    public int ProviderID { get; set; }
    public int PaymentID { get; set; }
    public DateTime DistributionDate { get; set; }
    public decimal DistributionAmount { get; set; }

    public Provider Provider { get; set; }
    public Payment Payment { get; set; }
}
namespace EXCELGRAPHING.Models;

public class Payment
{
    public int PaymentID { get; set; }
    public int ClaimID { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public string Status { get; set; }
    public int PaymentMethodID { get; set; }

    public Claim Claim { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<Distribution> Distributions { get; set; }
}
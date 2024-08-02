namespace EXCELGRAPHING.Models;

public class PayablePayment
{
    public int PayablePaymentID { get; set; }
    public int ProviderID { get; set; }
    public int PaymentID { get; set; }
    public decimal PayableAmount { get; set; }
    public DateTime PayableDate { get; set; }
    public string Status { get; set; }

    public Provider Provider { get; set; }
    public Payment Payment { get; set; }
}
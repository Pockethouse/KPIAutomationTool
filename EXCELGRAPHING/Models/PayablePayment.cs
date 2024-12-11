using System.ComponentModel.DataAnnotations.Schema;

namespace EXCELGRAPHING.Models;

public class PayablePayment
{
    public int PayablePaymentID { get; set; }
    public int ProviderID { get; set; }
    public int PaymentID { get; set; }
    public decimal PayableAmount { get; set; }
    public DateTime PayableDate { get; set; }
    public string Status { get; set; }
    //add productline id FK
    public int ProductLineID { get; set; }

    [ForeignKey("ProductLineID")]
    public ProductLine ProductLine { get; set; }


    public Provider Provider { get; set; }
    public Payment Payment { get; set; }
}
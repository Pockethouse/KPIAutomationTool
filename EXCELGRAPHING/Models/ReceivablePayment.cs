namespace EXCELGRAPHING.Models;

public class ReceivablePayment
{
    public int ReceivablePaymentID { get; set; }
    public int BankID { get; set; }
    public int PaymentID { get; set; }
    public decimal ReceivableAmount { get; set; }
    public DateTime ReceivableDate { get; set; }
    public string Status { get; set; }

    public Bank Bank { get; set; }
    public Payment Payment { get; set; }
}
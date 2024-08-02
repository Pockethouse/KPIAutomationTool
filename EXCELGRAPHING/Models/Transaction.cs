namespace EXCELGRAPHING.Models;

public class Transaction
{
    public int TransactionID { get; set; }
    public int PaymentID { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }

    public Payment Payment { get; set; }
}
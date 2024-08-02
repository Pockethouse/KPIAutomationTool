namespace EXCELGRAPHING.Models;

public class BankAccount
{
    public int BankAccountID { get; set; }
    public int BankID { get; set; }
    public int ProviderID { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }

    public Bank Bank { get; set; }
    public Provider Provider { get; set; }
}
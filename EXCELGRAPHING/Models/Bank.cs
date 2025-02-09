namespace EXCELGRAPHING.Models;

public class Bank
{
    public int BankID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public ICollection<BankAccount> BankAccounts { get; set; }
}
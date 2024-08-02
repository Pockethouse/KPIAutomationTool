namespace EXCELGRAPHING.Models;

public class Provider
{
    public int ProviderID { get; set; }
    public string Name { get; set; }
    public string Specialty { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public ICollection<Claim> Claims { get; set; }
    public ICollection<Distribution> Distributions { get; set; }
    public ICollection<BankAccount> BankAccounts { get; set; }
}
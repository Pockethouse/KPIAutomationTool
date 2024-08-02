namespace EXCELGRAPHING.Models;

public class PaymentMethod
{
    public int PaymentMethodID { get; set; }
    public string Method { get; set; }

    public ICollection<Payment> Payments { get; set; }
}
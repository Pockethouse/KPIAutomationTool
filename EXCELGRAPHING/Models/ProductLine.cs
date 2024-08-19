using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXCELGRAPHING.Models;

public class ProductLine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductLineID { get; set; }

    [Required]
    [StringLength(100)]
    
    [Column("ProductLine")]
    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<PayablePayment> PayablePayments { get; set; }
    
}
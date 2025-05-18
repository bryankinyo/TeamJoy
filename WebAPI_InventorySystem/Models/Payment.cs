
namespace WebAPI_InventorySystem.Models;
public class Payment
{
    public int PaymentID { get; set; }
    public int SalesOrderID { get; set; }
    public decimal AmountPaid { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
    public int StatusID { get; set; }

    public SalesOrder? SalesOrder { get; set; }
    public OrderStatus? Status { get; set; }
}
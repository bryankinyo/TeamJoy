
namespace WebAPI_InventorySystem.Models;
public class InventoryMovement
{
    public int InventoryMovementID { get; set; }
    public int ProductID { get; set; }          //FK
    public int QuantityChanged { get; set; }    
    public int MovementTypeID { get; set; }     //FK
    public DateTime Date { get; set; }
    public string? MovementReason { get; set; }

    public int? SalesOrderDetailID { get; set; } //FK
    public int? PurchaseOrderDetailID { get; set; } //FK

    public DateTime MovementDate { get; set; }
    public Product? Product { get; set; }
    public MovementType? MovementType { get; set; }
    public SalesOrderDetail? SalesOrderDetail { get; set; }
    public PurchaseOrderDetail? PurchaseOrderDetail { get; set; }
}
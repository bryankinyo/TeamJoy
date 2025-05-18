using WebAPI_InventorySystem.Models;

public class PurchaseOrderDetail
{
    public int PurchaseOrderDetailID { get; set; }
    public int PurchaseOrderID { get; set; } //fk
    public int ProductID { get; set; } //fk
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TotalPrice { get; set; }

    public PurchaseOrder? PurchaseOrder { get; set; }
    public Product? Product { get; set; }
}
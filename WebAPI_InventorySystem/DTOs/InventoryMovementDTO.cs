namespace WebAPI_InventorySystem.DTOs
{
    public class InventoryMovementDto
    {
        public int InventoryMovementID { get; set; }
        public int ProductID { get; set; }
        public int QuantityChanged { get; set; }
        public int MovementTypeID { get; set; }
        public DateTime MovementDate { get; set; }
        public int? SalesOrderDetailID { get; set; }
        public int? PurchaseOrderDetailID { get; set; }
        public string? MovementReason { get; set; }
    }
}

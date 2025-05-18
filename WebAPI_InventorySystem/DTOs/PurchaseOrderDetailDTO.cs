namespace WebAPI_InventorySystem.DTOs
{
    public class PurchaseOrderDetailDto
    {
        public int PurchaseOrderDetailID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

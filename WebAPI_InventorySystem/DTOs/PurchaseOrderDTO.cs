namespace WebAPI_InventorySystem.DTOs
{
    public class PurchaseOrderDto
    {
        public int PurchaseOrderID { get; set; }
        public int SupplierID { get; set; }
        public int EmployeeID { get; set; }
        public int StatusID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

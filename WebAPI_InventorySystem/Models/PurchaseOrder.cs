namespace WebAPI_InventorySystem.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderID { get; set; }
        public int SupplierID { get; set; }
        public DateTime OrderDate { get; set; }
        public int EmployeeID { get; set; }
        public int StatusID { get; set; }
        public decimal TotalAmount { get; set; }

        public Supplier? Supplier { get; set; }
        public Employee? Employee { get; set; }
        public OrderStatus? Status { get; set; }
    }
}

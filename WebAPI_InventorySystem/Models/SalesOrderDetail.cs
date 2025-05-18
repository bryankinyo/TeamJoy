namespace WebAPI_InventorySystem.Models
{
    public class SalesOrderDetail
    {
        public int SalesOrderDetailID { get; set; }
        public int SalesOrderID { get; set; } //fk
        public int ProductID { get; set; } //fk
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalPrice { get; set; }

        public SalesOrder? SalesOrder { get; set; }
        public Product? Product { get; set; }
    }

}

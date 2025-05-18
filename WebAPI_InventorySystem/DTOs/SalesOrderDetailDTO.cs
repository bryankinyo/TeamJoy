namespace WebAPI_InventorySystem.DTOs
{
    public class SalesOrderDetailDto
    {
        public int SalesOrderDetailID { get; set; }
        public int SalesOrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

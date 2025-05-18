namespace WebAPI_InventorySystem.DTOs
{
    public class SalesOrderDto
    {
        public int SalesOrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int StatusID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

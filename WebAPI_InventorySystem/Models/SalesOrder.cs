namespace WebAPI_InventorySystem.Models
{
    public class SalesOrder
    {
        public int SalesOrderID { get; set; }
        public int CustomerID { get; set; } //fk
        public DateTime OrderDate { get; set; }
        public int EmployeeID { get; set; } //fk
        public int StatusID { get; set; } //fk
        public decimal TotalAmount { get; set; }

        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
        public OrderStatus? Status { get; set; }
    }
}

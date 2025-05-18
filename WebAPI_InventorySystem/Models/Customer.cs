namespace WebAPI_InventorySystem.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}

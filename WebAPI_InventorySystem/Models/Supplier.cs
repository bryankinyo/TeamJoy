namespace WebAPI_InventorySystem.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; } = null!;
        public string? ContactPerson { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}

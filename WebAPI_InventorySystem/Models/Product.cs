namespace WebAPI_InventorySystem.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        public int? CategoryID { get; set; }  // Making it nullable

        public Category? Category { get; set; }
    }
}

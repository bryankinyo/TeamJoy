namespace WebAPI_InventorySystem.DTOs
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal QuantityInStock { get; set; }
        public int CategoryID { get; set; }
    }
}

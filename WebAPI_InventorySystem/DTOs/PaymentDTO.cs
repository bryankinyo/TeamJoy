namespace WebAPI_InventorySystem.DTOs
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int SalesOrderID { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public int Status { get; set; }
    }
}

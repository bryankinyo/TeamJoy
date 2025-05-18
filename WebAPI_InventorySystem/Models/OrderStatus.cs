namespace WebAPI_InventorySystem.Models;

using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

public class OrderStatus
{
    [Key]
    [JsonPropertyName("statusId")]
    public int StatusID { get; set; }
    
    [JsonPropertyName("statusName")]
    public string? StatusName { get; set; }
}
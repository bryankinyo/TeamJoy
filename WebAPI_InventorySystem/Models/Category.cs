using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_InventorySystem.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}

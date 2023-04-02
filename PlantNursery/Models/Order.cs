using System.ComponentModel.DataAnnotations;

namespace PlantNursery.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string? Email { get; set; }
        public string? UserID { get; set; }

        public List<OrderItem> OrderItem { get; set; }
    }
}

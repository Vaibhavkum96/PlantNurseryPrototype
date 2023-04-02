using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNursery.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        
        public int PlantID { get; set; }
        [ForeignKey("PlantID")]
        public Plant Plant { get; set; }

        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
    }
}

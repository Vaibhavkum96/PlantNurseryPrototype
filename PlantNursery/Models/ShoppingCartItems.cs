using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNursery.Models
{
    public class ShoppingCartItems
    {
        [Key]
        public int ID { get; set; }
        public Plant Plant { get; set; }
        public int Amount { get; set; }
        public string? ShoppingCartID { get; set; }

        
        
    }
}

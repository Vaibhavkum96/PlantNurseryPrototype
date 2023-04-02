using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNursery.Models
{
    public class Plant
    {
        public int ID { get; set; }
        public string PlantName { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public Category Category{ get; set; }
        public int Price { get; set; }
        
        public int Quantity { get; set; }
    }
}

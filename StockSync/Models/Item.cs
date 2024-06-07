using System.ComponentModel.DataAnnotations;

namespace StockSync.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        [MaxLength(100)]
        public string ItemName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Img { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; } 
        public ICollection<Movement> StockMovements { get; set; } = new List<Movement>();

    }
}

using System.ComponentModel.DataAnnotations;

namespace StockSync.Models
{
    public class Movement
    {
        public int MovementID { get; set; }
        public int ItemID { get; set; }
        public DateTime MovementDate { get; set; }
        public int Quantity { get; set; }
        [MaxLength(25)]
        public string MovementType { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Notes { get; set; } = string.Empty;

        public Item Item { get; set; } = default!;
    }
}

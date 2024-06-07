using System.ComponentModel.DataAnnotations;

namespace StockSync.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}

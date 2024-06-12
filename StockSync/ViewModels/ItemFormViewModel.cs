namespace StockSync.ViewModels
{
    public class ItemFormViewModel
    {
        [MaxLength(100)]
        public string ItemName { get; set; } = string.Empty;
       
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}

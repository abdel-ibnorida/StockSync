namespace StockSync.ViewModels
{
    public class EditItemFormViewModel : ItemFormViewModel
    {
        public int ItemId { get; set; }
        public string? CurrentImg { get; set; }

        [AllowedExtensionsAttribute(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Img { get; set; } = default!;
    }
}

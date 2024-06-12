namespace StockSync.ViewModels
{
    public class CreateItemFormViewModel : ItemFormViewModel
    {
        [AllowedExtensionsAttribute(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Img { get; set; } = default!;

    }
}

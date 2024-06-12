namespace StockSync.Settings
{
    public static class FileSettings
    {
        public const string HomeImagesPath = "/assets/images/home";
        public const string ItemImagesPath = "/assets/images/items";
        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}

namespace StockSync.Services
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}

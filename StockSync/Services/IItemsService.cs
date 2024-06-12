namespace StockSync.Services
{
    public interface IItemsService
    {
        Task Create(CreateItemFormViewModel model);
        IEnumerable<Item> GetAll();
        Item? GetById(int id);
        Task<Item?> Update(EditItemFormViewModel model);
    }
}

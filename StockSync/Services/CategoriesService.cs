namespace StockSync.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly MyDbContext _context;
        public CategoriesService(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Categories
                .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .ToList();
        }
    }
}

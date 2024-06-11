namespace StockSync.Services
{
    public class ItemService : IItemsService
    {
        private readonly MyDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;
        public ItemService(MyDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }
        public async Task Create(CreateItemFormViewModel model)
        {
            var imageName = $"{Guid.NewGuid()}{Path.GetExtension(model.Img.FileName)}";
            var path = Path.Combine(_imagesPath, imageName);
            using var stream = File.Create(path);
            await model.Img.CopyToAsync(stream);

            Item item = new()
            {
                ItemName = model.ItemName,
                CategoryID = model.CategoryID,
                Img = imageName,
                Description = model.Description,
                Quantity = model.Quantity,
                Price = model.Price,
            };
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();

            Movement movement = new()
            {
                ItemID = item.ItemID,
                MovementDate = DateTime.UtcNow,
                Quantity = model.Quantity,
                MovementType = "Initial",
                Notes = "Creazione iniziale dell'item",
            };
            _dbContext.Movements.Add(movement);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Item> GetAll()
        {
            return _dbContext.Items
           .Include(g => g.Category)
           .AsNoTracking()
           .ToList();
        }
    }
}

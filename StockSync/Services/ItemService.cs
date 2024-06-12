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
            var imageName = await SaveCover(model.Img);

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
           .Include(i => i.Category)
           .AsNoTracking()
           .ToList();
        }
        public Item? GetById(int id)
        {
            return _dbContext.Items
           .Include(i => i.Category)
           .AsNoTracking()
           .SingleOrDefault(i => i.ItemID == id);
        }
        public async Task<Item?> Update(EditItemFormViewModel model)
        {
            var item = _dbContext.Items
                .SingleOrDefault(i => i.ItemID == model.ItemId);

            if (item is null)
                return null;

            var hasNewImg = model.Img is not null;
            var oldImg = item.Img;

            item.ItemName = model.ItemName;
            item.Description = model.Description;
            item.CategoryID = model.CategoryID;
            
            if (hasNewImg)
            {
                item.Img = await SaveCover(model.Img!);
            }

            var effectedRows = _dbContext.SaveChanges();

            if (effectedRows > 0)
            {
                if (hasNewImg)
                {
                    var img = Path.Combine(_imagesPath, oldImg);
                    File.Delete(img);
                }

                return item;
            }
            else
            {
                var img = Path.Combine(_imagesPath, item.Img);
                File.Delete(img);

                return null;
            }
        }
        private async Task<string> SaveCover(IFormFile cover)
        {
            var imgName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(_imagesPath, imgName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return imgName;
        }
    }
}

namespace StockSync.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IItemsService _itemService;
        public ItemsController(ICategoriesService categoriesService, IItemsService itemService)
        {
            _categoriesService = categoriesService;
            _itemService = itemService;
        }
        public IActionResult Index()
        {
            var games = _itemService.GetAll();
            return View(games);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateItemFormViewModel viewModel = new()
            {
                Categories = _categoriesService.GetSelectList()
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateItemFormViewModel model)
        {
            if (!ModelState.IsValid) {
                model.Categories = _categoriesService.GetSelectList();
                return View(model);
            }
            await _itemService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            Item item = _itemService.GetById(id);

            if (item is null)
                return NotFound();

            return View(item);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _itemService.GetById(id);

            if (item is null)
                return NotFound();

            EditItemFormViewModel viewModel = new()
            {
                ItemId = id,
                ItemName = item.ItemName,
                Description = item.Description,
                CategoryID = item.CategoryID,
                Categories = _categoriesService.GetSelectList(),
                Price = item.Price,
                Quantity = item.Quantity,
                CurrentImg = item.Img
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditItemFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();
                return View(model);
            }
            
            var item = await _itemService.Update(model);

            if (item is null)
                return Content("errore null");

            return RedirectToAction(nameof(Index));
           
        }
    }

}

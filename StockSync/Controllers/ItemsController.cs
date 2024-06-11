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
        }
}

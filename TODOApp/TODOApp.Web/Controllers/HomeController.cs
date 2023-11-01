using Microsoft.AspNetCore.Mvc;
using TODOApp.Data.Repositories.Interfaces;

namespace TODOApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkItemRepository _iWorkItemRepository;

        public HomeController(IWorkItemRepository iWorkItemRepository)
        {
            _iWorkItemRepository = iWorkItemRepository;
        }
        public async Task<IActionResult> Index()
        {
            var allWorkItems = await _iWorkItemRepository.GetAllWorkItems();

            return View(allWorkItems);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TODOApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

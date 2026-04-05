using Microsoft.AspNetCore.Mvc;

namespace myprojectpharmacy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

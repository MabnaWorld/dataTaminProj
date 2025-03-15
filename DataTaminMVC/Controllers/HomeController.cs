using Microsoft.AspNetCore.Mvc;

namespace DataTaminMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

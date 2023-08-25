using Microsoft.AspNetCore.Mvc;

namespace HaliSaham.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GostergePaneliController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Rol() => View();
        public IActionResult HaliSahalar() => View();
        public IActionResult Kullanicilar() => View();
        public IActionResult Sehirler() => View();
        
    }
}

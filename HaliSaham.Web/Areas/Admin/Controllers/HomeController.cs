using Microsoft.AspNetCore.Mvc;

namespace HaliSaham.Web.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}

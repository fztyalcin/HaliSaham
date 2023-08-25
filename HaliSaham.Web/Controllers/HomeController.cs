using HaliSaham.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HaliSaham.Web.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index() => View();
        public IActionResult Hakkimizda() => View();
        public IActionResult Iletisim() => View();
        public IActionResult KvkkVeGizlilik() => View();
        public IActionResult HaliSahalar() => View();
        public IActionResult SiteKullanimSartlari() => View();
        public IActionResult HaliSahalariGetirBySehirId() => View();
        public IActionResult Sehirler() => View();


        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
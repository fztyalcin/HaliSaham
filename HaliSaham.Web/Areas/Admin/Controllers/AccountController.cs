using HaliSaham.Web.Admin.Code;
using HaliSaham.Web.Admin.Code.Rest;
using HaliSaham.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace HaliSaham.Web.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Login() => View();
        public IActionResult GirisYap(LoginModel model) 
        {
            UserRestClient client = new UserRestClient();
            dynamic result = client.Login(model.EPosta, model.Sifre);

            bool success = result.success;

            if (success)
            {
                Repo.Session.EPosta = model.EPosta;
                Repo.Session.Token = (string)result.data;
                Repo.Session.Rol = (string) result.rol;
                
                return RedirectToAction("Index","Home");
            }
            else 
            {
                ViewBag.LoginError = (string)result.message;
                return View("Login");
            }

            
        }
    }
}

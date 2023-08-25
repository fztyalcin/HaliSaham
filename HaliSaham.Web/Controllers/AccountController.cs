using HaliSaham.Web.Code;
using HaliSaham.Web.Code.Rest;
using HaliSaham.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace HaliSaham.Web.Controllers
{
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

        public IActionResult UyeOl(UyeOlModel model)
        {
            UserRestClient client = new UserRestClient();
            dynamic result = client.UyeOl(model.EPosta, model.Sifre);

            bool success = result.success;

            if (success)
            {
                Repo.Session.EPosta = model.EPosta;
                Repo.Session.Token = (string)result.data;
                Repo.Session.Rol = (string)result.rol;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginError = (string)result.message;
                return View("UyeOl");
            }


        }
    }
}

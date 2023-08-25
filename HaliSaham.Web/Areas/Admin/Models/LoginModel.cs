using Microsoft.AspNetCore.Mvc;

namespace HaliSaham.Web.Areas.Admin.Models
{
    [Area("Admin")]
    public class LoginModel
    {
        public string EPosta { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
    }
}

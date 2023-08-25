using HaliSaham.Model;
using HaliSaham.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;


namespace HaliSaham.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]

    public class RolController : BaseController
    {

        public RolController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("TumRoller")]
        public dynamic TumRoller()
        {
            List<Rol> items = repo.RolRepository.FindAll().ToList<Rol>();
            return new
            {
                success = true,
                data = items
            };
        }


        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Rol item = new Rol()
            {
                Id = json.Id,
                Ad = json.Ad
            };

            if (string.IsNullOrEmpty(item.Ad))
            {
                return new
                {
                    sucess = false,
                    message = "Ad alanı boş geçilemez"
                };
            }
            if (item.Ad.Length > 20)
            {
                return new
                {
                    sucess = false,
                    message = "Ad alanı maksimum 20 karakter olabilir"
                };
            }

            if (item.Id > 0)
            {
                repo.RolRepository.Update(item);
            }
            else
            {
                repo.RolRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true
            };
        }


        [HttpDelete("Sil")]
        public dynamic Sil(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz id"
                };
            }

            repo.RolRepository.RolSil(id);
            return new
            {
                success = true
            };
        }
    }
}

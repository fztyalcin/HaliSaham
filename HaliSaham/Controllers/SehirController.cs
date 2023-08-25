using HaliSaham.Model;
using HaliSaham.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace HaliSaham.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController : BaseController
    {
        public SehirController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            
        }
        [HttpGet("TumSehirler")]
        public dynamic TumSehirler()
        {
            List<Sehir> items;

            if (!cache.TryGetValue("TumSehirler", out items))
            {
                items = repo.SehirRepository.FindAll().ToList<Sehir>();

                cache.Set("TumSehirler", items, DateTimeOffset.UtcNow.AddHours(1));

            }

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet ("AnaSayfaSehirler")]
        public dynamic AnaSayfaSehirler ()
        {
            List<Sehir> items = repo.SehirRepository.TumSehirler();
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
            Sehir item = new Sehir()
                 {
                       Id = json.Id,
                       Ad = json.Ad,
                
                 };

                repo.SehirRepository.Create(item);

            

            repo.SaveChanges();
            cache.Remove("TumSehirler");

            return new
            {
                success = true
            };

        }


     
       // [Authorize(Roles = "Admin")]

        [HttpDelete("Sil")]
        public dynamic Sil(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz Id!"
                };
            }
            repo.SehirRepository.SehirSil(id);

            return new
            {
                success = true
            };
        }

    }
}

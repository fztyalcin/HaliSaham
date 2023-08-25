using HaliSaham.Model;
using HaliSaham.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace HaliSaham.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiyatController : BaseController
    {
        public FiyatController (RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("TumFiyatlar")]
        public dynamic TumFiyatlar()
        {
            List<Fiyat> items;

            if (!cache.TryGetValue("TumFiyatlar", out items))
            {
                items = repo.FiyatRepository.FindAll().ToList<Fiyat>();

                cache.Set("TumFiyatlar", items, DateTimeOffset.UtcNow.AddHours(1));

            }

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
            Fiyat item = new Fiyat()
            {
                Id = json.Id,
                Ad = json.Ad,
                Bedel = json.Bedel,

            };

            if (item.Id > 0)
                repo.FiyatRepository.Update(item);
            else
                repo.FiyatRepository.Create(item);

            repo.SaveChanges();
            cache.Remove("TumFiyatlar");

            return new
            {
                success = true
            };

        }


        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            Fiyat item = repo.FiyatRepository.FindByCondition(a => a.Id == id).SingleOrDefault<Fiyat>();
            return new
            {
                success = true,
                data = item
            };
        }
        [HttpDelete("Id")]
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
            repo.FiyatRepository.FiyatSil(id);

            return new
            {
                success = true
            };
        }
    }
}

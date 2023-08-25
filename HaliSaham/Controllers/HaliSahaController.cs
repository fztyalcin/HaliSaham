using HaliSaham.Model;
using HaliSaham.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace HaliSaham.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HaliSahaController : BaseController
    {
        public HaliSahaController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("HaliSahalar/{sehirId}")]
        public dynamic HaliSahalar(int sehirId)
        {

            List<HaliSaha> items = repo.HaliSahaRepository.HaliSahalariGetirBySehirId(sehirId);

            return new
            {
                success = true,
                data = items
            };
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("TumHaliSahalar")]
        public dynamic TumHaliSahalar()
        {
            List<HaliSaha> items;

            if (!cache.TryGetValue("TumHaliSahalar", out items))
            {
                items = repo.HaliSahaRepository.FindAll().ToList<HaliSaha>();

                cache.Set("TumHaliSahalar", items, DateTimeOffset.UtcNow.AddHours(1));

            }

            return new
            {
                success = true,
                data = items
            };
        }

        //[Authorize(Roles = "Admin,KurumsalMusteri")]
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());
            HaliSaha item = new HaliSaha()
            {
                Id = json.Id,
                Ad = json.Ad,
                Adres = json.Adres,
                MaksimumKapasite = json.MaksimumKapasite,
                KurumsalMusteriId = json.KurumsalMusteriId,
                SehirId = json.SehirId,
                

            };

            if (item.Id > 0)
                repo.HaliSahaRepository.Update(item);
            else
                repo.HaliSahaRepository.Create(item);

            repo.SaveChanges();
            cache.Remove("TumHaliSahalar");

            return new
            {
                success = true
            };

        }


        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            HaliSaha item = repo.HaliSahaRepository.FindByCondition(a => a.Id == id).SingleOrDefault<HaliSaha>();
            return new
            {
                success = true,
                data = item
            };
        }

        [Authorize(Roles = "Admin")]

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
            repo.HaliSahaRepository.HaliSahaSil(id);

            return new
            {
                success = true
            };
        }
    }
}

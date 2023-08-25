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
    public class KurumsalMusteriController : BaseController
    {
        public KurumsalMusteriController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("TumKurumsalMusteriler")]
        public dynamic TumKurumsalMusteriler()
        {
            List<KurumsalMusteri> items;

            if (!cache.TryGetValue("TumKurumsalMusteriler", out items))
            {
                items = repo.KurumsalMusteriRepository.FindAll().ToList<KurumsalMusteri>();

                cache.Set("TumKurumsalMusteriler", items, DateTimeOffset.UtcNow.AddHours(1));

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
            KurumsalMusteri item = new KurumsalMusteri()
            {
                Id = json.Id,
                KullaniciId = json.KullaniciId,
                FirmaAd = json.FirmaAd,
                Adres = json.Adres,
                VergiNo = json.VergiNo,
                HaliSahaId = json.HaliSahaId,

            };

            if (item.Id > 0)
                repo.KurumsalMusteriRepository.Update(item);
            else
                repo.KurumsalMusteriRepository.Create(item);

            repo.SaveChanges();
            cache.Remove("TumKurumsalMusteriler");

            return new
            {
                success = true
            };

        }


        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            KurumsalMusteri item = repo.KurumsalMusteriRepository.FindByCondition(a => a.Id == id).SingleOrDefault<KurumsalMusteri>();
            return new
            {
                success = true,
                data = item
            };
        }
    }
}

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
    public class RandevuController : BaseController
    {
        public RandevuController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("TumRandevular")]
        public dynamic TumRandevular()
        {
            List<Randevu> items;

            if (!cache.TryGetValue("TumRandevular", out items))
            {
                items = repo.RandevuRepository.FindAll().ToList<Randevu>();

                cache.Set("TumRandevular", items, DateTimeOffset.UtcNow.AddHours(1));

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
            Randevu item = new Randevu()
            {
                Id = json.Id,
                Tarih = json.Tarih,
                KullaniciId = json.KullaniciId,
                HaliSahaId = json.HaliSahaId,
                FiyatId = json.FiyatId,

            };

            if (item.Id > 0)
                repo.RandevuRepository.Update(item);
            else
                repo.RandevuRepository.Create(item);

            repo.SaveChanges();
            cache.Remove("TumRandevular");

            return new
            {
                success = true
            };

        }


        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            Randevu item = repo.RandevuRepository.FindByCondition(a => a.Id == id).SingleOrDefault<Randevu>();
            return new
            {
                success = true,
                data = item
            };
        }
    }
}

using FluentValidation;
using HaliSaham.Api.Code.Validations;
using HaliSaham.Model;
using HaliSaham.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace HaliSaham.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : BaseController
    {
        public KullaniciController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpPost("UyeOl")]
        public dynamic UyeOl([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string ePosta = json.EPosta;
            string sifre = json.Sifre;

            Kullanici item = new ()
            {
                EPosta = ePosta,
                Sifre = sifre,
                RolId = Enums.Roller.Musteri
            };

            Kullanici? kullanici = repo.KullaniciRepository.FindByCondition(k => k.EPosta == item.EPosta).SingleOrDefault<Kullanici>();
            if (kullanici != null)
            {
                return new
                {
                    success = false,
                    message = "Bu e-Posta zaten kullanılıyor"
                };
            }

            KullaniciValidator validator = new KullaniciValidator();
            validator.ValidateAndThrow(item);

            repo.KullaniciRepository.Create(item);
            repo.SaveChanges();

            return new
            {
                success = true
            };
        }

        [HttpGet("TumKullanicilar")]
        public dynamic TumKullanicilar()
        {
            List<Kullanici> items;

            if (!cache.TryGetValue("TumKullanicilar", out items))
            {
                items = repo.KullaniciRepository.FindAll().ToList<Kullanici>();

                cache.Set("TumKullanicilar", items, DateTimeOffset.UtcNow.AddHours(1));

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
            Kullanici item = new Kullanici()
            {
                Id = json.Id,
                Ad = json.Ad,
                Soyad = json.Soyad,
                Sifre = json.Sifre,
                EPosta = json.EPosta,
                Telefon = json.Telefon,
                RolId = json.RolId,

            };

            if (item.Id > 0)
                repo.KullaniciRepository.Update(item);
            else
                repo.KullaniciRepository.Create(item);

            repo.SaveChanges();
            cache.Remove("TumKullanicilar");

            return new
            {
                success = true
            };

        }


        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            Kullanici item = repo.KullaniciRepository.FindByCondition(a => a.Id == id).SingleOrDefault<Kullanici>();
            return new
            {
                success = true,
                data = item
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

            repo.KullaniciRepository.KullaniciSil(id);
            return new
            {
                success = true
            };
        }

    }
}

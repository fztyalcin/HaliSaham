using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Model
{
    [Table ("tblKurumsalMusteri")]
    public class KurumsalMusteri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string FirmaAd { get; set; }
        public string Adres { get; set; }
        public int? VergiNo { get; set; }
        public int? HaliSahaId { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}

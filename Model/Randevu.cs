using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Model
{
    [Table ("tblRandevu")]
    public class Randevu
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public int KullaniciId { get; set; }
        public int HaliSahaId { get; set; }
        public int FiyatId { get; set; }
    }
}

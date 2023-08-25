using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Model
{
    [Table ("tblKullanici")]
    public class Kullanici
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string Sifre { get; set; }
        public string? EPosta { get; set; }
        public string? Telefon { get; set; }
        public int RolId { get; set; }

    }
}

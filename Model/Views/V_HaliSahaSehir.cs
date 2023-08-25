using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Model.Views
{
    [Table ("V_HaliSahaSehir")]
    public class V_HaliSahaSehir
    {
        public int HaliSahaId { get; set; }
        public string HaliSahaAd { get; set; }
        public string SehirAd { get; set; }
        public int SehirId { get; set;}
    }
}

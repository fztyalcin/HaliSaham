using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Model
{
    [Table ("tblHaliSaha")]
    public class HaliSaha
    {
        public HaliSaha() 
        {

        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public int? MaksimumKapasite { get; set; }
        public int KurumsalMusteriId { get; set; }
        public int SehirId { get; set; }

        
    }
}

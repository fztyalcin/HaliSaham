using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Model
{
    [Table ("tblFiyat")]
    public class Fiyat
    {
        public int Id { get; set; }
        public string Ad { get ; set; }
        public decimal Bedel { get; set; }

    }
}

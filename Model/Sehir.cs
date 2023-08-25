using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table ("tblSehir")]
    public class Sehir
    {
        public int Id { get; set; }
        public string Ad { get; set; }



    }
}
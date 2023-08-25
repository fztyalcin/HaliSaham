using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Repository
{
    public class SehirRepository : RepositoryBase <Sehir>
    {
        public SehirRepository(RepositoryContext context) : base(context)
        {
        }

        public List<Sehir>TumSehirler() => RepositoryContext.Sehirler.OrderBy(s=>s.Id).ToList();

        public void SehirSil(int sehirId)
        {
            RepositoryContext.Sehirler.Where(s => s.Id == sehirId).ExecuteDelete();
        }
    }
}

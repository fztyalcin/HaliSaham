using HaliSaham.Model;
using HaliSaham.Model.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Repository
{
    public class HaliSahaRepository : RepositoryBase<HaliSaha>
    {
        public HaliSahaRepository(RepositoryContext context) : base(context)
        {
        }

        public List<HaliSaha> HaliSahalariGetirBySehirId(int sehirId)
        {
            List<HaliSaha> items = (from h in RepositoryContext.HaliSahalar
                                join s in RepositoryContext.HaliSahaSehirler on h.Id equals s.HaliSahaId
                                where s.SehirId == sehirId
                                select h).ToList<HaliSaha>();
            return items;
        }

        
        public void HaliSahaSil(int haliSahaId)
        {
            RepositoryContext.HaliSahalar.Where(h => h.Id == haliSahaId).ExecuteDelete();
        }
    }
}

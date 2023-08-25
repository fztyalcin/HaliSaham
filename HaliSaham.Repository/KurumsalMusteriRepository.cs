using HaliSaham.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Repository
{
    public class KurumsalMusteriRepository : RepositoryBase <KurumsalMusteri>
    {
        public KurumsalMusteriRepository(RepositoryContext context) : base(context)
        {
        }

        public void KurumsalMusteriSil(int kurumsalMusteriId)
        {
            RepositoryContext.KurumsalMusteriler.Where(r => r.Id == kurumsalMusteriId).ExecuteDelete();
        }
    }
}

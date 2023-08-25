using HaliSaham.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Repository
{
    public class RandevuRepository : RepositoryBase <Randevu>
    {
        public RandevuRepository(RepositoryContext context) : base(context)
        {
        }

        public void RandevuSil(int randevuId)
        {
            RepositoryContext.Randevular.Where(r => r.Id == randevuId).ExecuteDelete();
        }
    }
}

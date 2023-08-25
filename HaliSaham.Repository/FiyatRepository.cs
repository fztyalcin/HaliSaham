using HaliSaham.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Repository
{
    public class FiyatRepository : RepositoryBase<Fiyat>
    {
        public FiyatRepository(RepositoryContext context) : base(context)
        {
        }

        public void FiyatSil(int fiyatId)
        {
            RepositoryContext.Fiyatlar.Where(r => r.Id == fiyatId).ExecuteDelete();
        }
    }
}

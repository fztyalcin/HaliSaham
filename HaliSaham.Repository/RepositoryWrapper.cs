using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaham.Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext context;

        private FiyatRepository fiyatRepository;
        private HaliSahaRepository haliSahaRepository;
        private KullaniciRepository kullaniciRepository;
        private KurumsalMusteriRepository kurumsalMusteriRepository;
        private RolRepository rolRepository;
        private RandevuRepository randevuRepository;
        private SehirRepository sehirRepository;

        public RepositoryWrapper (RepositoryContext context)
        {
            this.context = context;
        }

        
        public FiyatRepository FiyatRepository
        {
            get
            {
                if (fiyatRepository == null)
                    fiyatRepository = new FiyatRepository(context);
                return fiyatRepository;
            }
        }

        public HaliSahaRepository HaliSahaRepository
        {
            get
            {
                if (haliSahaRepository == null)
                    haliSahaRepository = new HaliSahaRepository(context);
                return haliSahaRepository;
            }
        }

        public KullaniciRepository KullaniciRepository
        {
            get
            {
                if (kullaniciRepository == null)
                    kullaniciRepository = new KullaniciRepository(context);
                return kullaniciRepository;
            }
        }

        public KurumsalMusteriRepository KurumsalMusteriRepository
        {
            get
            {
                if (kurumsalMusteriRepository == null)
                    kurumsalMusteriRepository = new KurumsalMusteriRepository(context);
                return kurumsalMusteriRepository;
            }
        }

        public RolRepository RolRepository
        {
            get
            {
                if (rolRepository == null)
                    rolRepository = new RolRepository(context);
                return rolRepository;
            }
        }

        public RandevuRepository RandevuRepository
        {
            get
            {
                if (randevuRepository == null)
                    randevuRepository = new RandevuRepository(context);
                return randevuRepository;
            }
        }

        public SehirRepository SehirRepository
        {
            get
            {
                if (sehirRepository == null)
                    sehirRepository = new SehirRepository(context);
                return sehirRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

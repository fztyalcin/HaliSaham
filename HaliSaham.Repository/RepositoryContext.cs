using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HaliSaham.Model;
using Model;
using HaliSaham.Model.Views;

namespace HaliSaham.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base (options) 
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<V_HaliSahaSehir>().HasNoKey();
           // modelBuilder.Entity<Kullanici>().Property(d => d.KayitTarih).HasDefaultValue();
        }

        public DbSet <Fiyat> Fiyatlar { get; set; }
        public DbSet <HaliSaha> HaliSahalar { get; set; }
        public DbSet <Kullanici> Kullanicilar { get; set; }
        public DbSet <KurumsalMusteri> KurumsalMusteriler { get; set; }
        public DbSet <Rol> Roller { get; set; }
        public DbSet <Randevu> Randevular { get; set; }
        public DbSet <Sehir> Sehirler { get; set; }
        public DbSet <V_HaliSahaSehir> HaliSahaSehirler { get; set; } 
    }
}

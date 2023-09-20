using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PiRang_WPF.Model
{
    class AppDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        // DATASETS
        public DbSet<WargaDesa> WargaDesas => Set<WargaDesa>();
        public DbSet<PerangkatDesa> PerangkatDesas => Set<PerangkatDesa>();
        public DbSet<Barang> Barangs => Set<Barang>();
        public DbSet<PeminjamanBarang> PeminjamanBarangs => Set<PeminjamanBarang>();
        public DbSet<Pengembalian> Pengembalians => Set<Pengembalian>();

        // DB CONNECTION STUFF
        public AppDBContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("Database"));
        }

        //// WargaDesa
        // GET METHODS
        public List<WargaDesa> GetAllWargaDesas()
        {
            return WargaDesas.ToList();
        }
        public WargaDesa GetWargaDesaById(int id)
        {
            return WargaDesas.FirstOrDefault(e => e.Id == id);
        }
        // GET METHODS
        //// WargaDesa

        //// PerangkatDesa
        // GET METHODS
        public List<PerangkatDesa> GetAllPerangkatDesas()
        {
            return PerangkatDesas.ToList();
        }
        public PerangkatDesa GetPerangkatDesaById(int id)
        {
            return PerangkatDesas.FirstOrDefault(e => e.Id == id);
        }
        // GET METHODS
        //// PerangkatDesa

        //// Barang
        // GET METHODS
        public List<Barang> GetAllBarangs()
        {
            return Barangs.ToList();
        }
        public Barang GetBarangById(int id)
        {
            return Barangs.FirstOrDefault(e => e.Id == id);
        }
        // GET METHODS
        //// Barang

        //// PeminjamanBarang
        // GET METHODS
        public List<PeminjamanBarang> GetAllPeminjamanBarangs()
        {
            return PeminjamanBarangs.ToList();
        }
        public PeminjamanBarang GetPeminjamanBarangById(int id)
        {
            return PeminjamanBarangs.FirstOrDefault(e => e.Id == id);
        }
        // GET METHODS
        //// PeminjamanBarang

        //// Pengembalian
        // GET METHODS
        public List<Pengembalian> GetAllPengembalians()
        {
            return Pengembalians.ToList();
        }
        public Pengembalian GetPengembalianById(int id)
        {
            return Pengembalians.FirstOrDefault(e => e.Id == id);
        }
        // GET METHODS
        //// Pengembalian
    }
}

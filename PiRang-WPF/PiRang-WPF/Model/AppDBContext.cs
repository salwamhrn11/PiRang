using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PiRang_WPF.Model
{
    partial class AppDBContext : DbContext
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


    }
}

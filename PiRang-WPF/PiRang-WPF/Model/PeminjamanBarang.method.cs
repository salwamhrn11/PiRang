using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace PiRang_WPF.Model
{
    partial class AppDBContext : DbContext
    {
        //// PeminjamanBarang
        // GET METHODS (Retrieving Data)
        public List<PeminjamanBarang> GetAllPeminjamanBarangs()
        {
            return PeminjamanBarangs.ToList();
        }
        public PeminjamanBarang GetPeminjamanBarangById(int id)
        {
            return PeminjamanBarangs.FirstOrDefault(e => e.Id == id);
        }

        // POST METHODS (Add data to table)
        public void AddPeminjamanBarang(PeminjamanBarang peminjaman)
        {
            PeminjamanBarangs.Add(peminjaman);
            SaveChanges();
        }
    }
}

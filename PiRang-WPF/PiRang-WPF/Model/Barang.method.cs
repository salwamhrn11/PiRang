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
        // GET METHODS (Retrieving Data)
        public List<Barang> GetAllBarangs()
        {
            return Barangs.ToList();
        }
        public Barang GetBarangById(int id)
        {
            return Barangs.FirstOrDefault(e => e.Id == id);
        }

        // POST METHODS (Adding data to table)
        public void AddBarang(Barang barang)
        {
            Barangs.Add(barang);
            SaveChanges();
        }
    }
}

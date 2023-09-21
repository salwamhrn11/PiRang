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
        public List<Pengembalian> GetAllPengembalians()
        {
            return Pengembalians.ToList();
        }
        public Pengembalian GetPengembalianById(int id)
        {
            return Pengembalians.FirstOrDefault(e => e.Id == id);
        }

        // POST METHODS (Adding data to table)
        public void AddPengembalian(Pengembalian pengembalian)
        {
            Pengembalians.Add(pengembalian);
            SaveChanges();
        }
    }
}

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
        public List<PerangkatDesa> GetAllPerangkatDesas()
        {
            return PerangkatDesas.ToList();
        }
        public PerangkatDesa GetPerangkatDesaById(int id)
        {
            return PerangkatDesas.FirstOrDefault(e => e.Id == id);
        }

        // POST METHODS (Adding data to table)
        public void AddPerangkatDesa(PerangkatDesa perangkatdesa)
        {
            PerangkatDesas.Add(perangkatdesa);
            SaveChanges();
        }
    }
}

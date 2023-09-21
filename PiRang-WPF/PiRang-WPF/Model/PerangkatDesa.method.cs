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
        public PerangkatDesa GetPerangkatDesaByUsername(string username)
        {
            return PerangkatDesas.FirstOrDefault(e => e.Username == username);
        }

        // POST METHODS (Add data to table)
        public void AddPerangkatDesa(PerangkatDesa perangkatdesa)
        {
            PerangkatDesas.Add(perangkatdesa);
            SaveChanges();
        }
        // UPDATE METHODS (Edit data from table)
        public void EditPerangkatDesa(PerangkatDesa perangkatdesa)
        {
            // TODO
        }
    }
}

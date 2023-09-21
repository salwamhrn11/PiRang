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
        public List<WargaDesa> GetAllWargaDesas()
        {
            return WargaDesas.ToList();
        }
        public WargaDesa GetWargaDesaByEmail(string email)
        {
            return WargaDesas.FirstOrDefault(e => e.Email == email);
        }

        // POST METHODS (Add data to table)
        public void AddWargaDesa(WargaDesa wargadesa)
        {
            WargaDesas.Add(wargadesa);
            SaveChanges();
        }

        // UPDATE METHODS (Edit data from table)
        public void EditWarga(WargaDesa warga) 
        {
            // TODO
        }
    }
}

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
        public WargaDesa GetWargaDesaById(int id)
        {
            return WargaDesas.FirstOrDefault(e => e.Id == id);
        }

        // POST METHODS (Adding data to table)
        public void AddWargaDesa(WargaDesa wargadesa)
        {
            WargaDesas.Add(wargadesa);
            SaveChanges();
        }
    }
}

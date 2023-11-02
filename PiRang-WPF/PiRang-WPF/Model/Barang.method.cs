using System;
using System.Collections.Generic;
using System.Data;

namespace PiRang_WPF.Model;

class BarangMethod
{
    public static List<Barang> ConvertDataTableToList(DataTable dataTable)
    {
        List<Barang> barangList = new List<Barang>();
        foreach (DataRow row in dataTable.Rows)
        {
            Barang barang = new Barang
            {
                Id = Convert.ToInt32(row["id"]),
                NamaBarang = row["nama_barang"].ToString(),
                Jumlah = Convert.ToInt32(row["jumlah"])
            };
            barangList.Add(barang);
        }
        return barangList;
    }
}

using System;
using System.Collections.Generic;
using System.Data;

namespace PiRang_WPF.Model;

public class PengembalianBarangMethod
{
    public static List<PengembalianBarang> ConvertDataTableToList(DataTable dataTable)
    {
        List<PengembalianBarang> pengembalianBarangList = new List<PengembalianBarang>();

        foreach (DataRow row in dataTable.Rows)
        {
            PengembalianBarang pengembalianBarang = new PengembalianBarang
            {
                PeminjamanBarangId = Convert.ToInt32(row["peminjaman_barang_id"]),
                BarangId = Convert.ToInt32(row["barang_id"]),
                WargaEmail = row["warga_email"].ToString(),
                Jumlah = Convert.ToInt32(row["jumlah"]),
                KondisiBarang = row["kondisi_barang"].ToString()
            };
            pengembalianBarangList.Add(pengembalianBarang);
        }

        return pengembalianBarangList;
    }
}

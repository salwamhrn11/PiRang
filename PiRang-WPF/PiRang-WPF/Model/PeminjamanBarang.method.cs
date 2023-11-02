using System.Collections.Generic;
using System.Data;
using System;

namespace PiRang_WPF.Model;

public class PeminjamanBarangMethod
{
    public static List<PeminjamanBarang> ConvertDataTableToList(DataTable dataTable)
    {
        List<PeminjamanBarang> peminjamanBarangList = new List<PeminjamanBarang>();
        foreach (DataRow row in dataTable.Rows)
        {
            PeminjamanBarang peminjamanBarang = new PeminjamanBarang
            {
                Id = Convert.ToInt32(row["id"]),
                BarangId = Convert.ToInt32(row["barang_id"]),
                NamaBarang = row["nama_barang"].ToString(),
                WargaEmail = row["warga_email"].ToString(),
                DurasiPeminjaman = Convert.ToInt32(row["durasi_peminjaman"]),
                Jumlah = Convert.ToInt32(row["jumlah"])
            };
            peminjamanBarangList.Add(peminjamanBarang);
        }
        return peminjamanBarangList;
    }
}

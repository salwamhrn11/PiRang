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
                BarangId = Convert.ToInt32(row["barang_id"]),
                WargaEmail = row["warga_email"].ToString(),
                JumlahKembali = Convert.ToInt32(row["jumlah_kembali"]),
                JumlahDipinjam = Convert.ToInt32(row["jumlah_dipinjam"]),
                KondisiBarang = row["kondisi_barang"].ToString()
            };
            pengembalianBarangList.Add(pengembalianBarang);
        }

        return pengembalianBarangList;
    }
}

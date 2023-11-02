using System;
using System.Collections.Generic;

namespace PiRang_WPF.Model;

public class PengembalianBarang
{
    public int PeminjamanBarangId { get; set; }
    public int BarangId { get; set; }
    public string WargaEmail { get; set; }
    public int Jumlah { get; set; }
    public string KondisiBarang { get; set; }
}
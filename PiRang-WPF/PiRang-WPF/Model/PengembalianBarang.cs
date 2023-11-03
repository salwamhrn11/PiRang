using System;
using System.Collections.Generic;

namespace PiRang_WPF.Model;

public class PengembalianBarang
{
    public int BarangId { get; set; }
    public string WargaEmail { get; set; }
    public int JumlahDipinjam { get; set; }
    public int JumlahKembali { get; set; }
    public string KondisiBarang { get; set; }
}
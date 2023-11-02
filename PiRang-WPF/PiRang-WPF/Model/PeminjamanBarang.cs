namespace PiRang_WPF.Model;

public class PeminjamanBarang
{
    public int Id { get; set; }
    public int BarangId { get; set; }
    public string NamaBarang { get; set; }
    public string WargaEmail { get; set; }
    public int Jumlah { get; set; }
    public int DurasiPeminjaman { get; set; }
}

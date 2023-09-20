using System;
using System.ComponentModel.DataAnnotations;

namespace PiRang_WPF.Model
{
    public class PeminjamanBarang
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Kondisi { get; set; }
        [Required]
        public string NIK { get; set; }
        [Required]
        public string PhoneNumber { get; set;}
        [Required]
        public int DurasiPeminjaman { get; set;}
        [Required]
        public int Jumlah { get; set; }
        
        public int BarangId { get; set; }
        public Barang Barang { get; set; }
    }
}